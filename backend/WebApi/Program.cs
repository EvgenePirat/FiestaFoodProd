using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using RealTimeHandler.Hubs;
using WebApi.DependencyResolve;
using WebApi.Utilities.Filters.CancellationFilter;
using WebApi.Utilities.Filters.FormFileFilter;
using WebApi.Utilities.Middleware.ExceptionsHandlers;
using Autofac.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<OperationCancelledExceptionFilter>();
    options.Filters.Add<FormFileOperationFilter>();
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//docker start naming
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User=SA;Password={dbPassword};TrustServerCertificate=true";
//var connectionString = builder.Configuration.GetConnectionString("StDatabase");
builder.Services.AddDbContext<StContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    cors =>
    {
        cors.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((_) => true)
            .AllowCredentials();
    }));

builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAnyOrigin", p => p
        .WithOrigins("null") // Origin of an html file opened in a browser
        .AllowAnyHeader()
        .AllowCredentials());
});
builder.Services.AddSignalR();

builder.Services.AddControllers()
    .AddJsonOptions(opt => { opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
builder.Services.AddSignalR()
    .AddHubOptions<OrderHub>(options => options.EnableDetailedErrors = true)
    .AddJsonProtocol(options =>
    {
        options.PayloadSerializerOptions.PropertyNamingPolicy = null;
    }); ;
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(
    containerBuilder => containerBuilder.RegisterModule(new BusinessModule()));

builder.Host.ConfigureContainer<ContainerBuilder>(
    containerBuilder => containerBuilder.RegisterModule(new MappersModules()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<ExceptionHandlerMiddleware>();
// Remove on release 
//app.UseTimeoutCancellationToken(TimeSpan.FromSeconds(10));

//app.UseHttpsRedirection();

//app.UseCors("CorsPolicy");
app.UseCors("AllowAnyOrigin");
app.MapHub<OrderHub>("/orderHub");


app.UseAuthorization();
app.MapControllers();

app.Run();
