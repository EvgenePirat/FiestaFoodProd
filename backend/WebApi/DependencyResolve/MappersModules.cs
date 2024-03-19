using Autofac;
using AutoMapper;
using Business.Mappers;
using WebApi.Mappers;

namespace WebApi.DependencyResolve
{
    public class MappersModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DishesProfile());
                cfg.AddProfile(new ProductDtoProfile());

                cfg.AddProfile(new PaginationProfile());

                cfg.AddProfile(new CategoryDtoProfile());
                cfg.AddProfile(new CategoryProfile());

                cfg.AddProfile(new UserProfile());
                cfg.AddProfile(new UserDtoProfile());
                
                cfg.AddProfile(new FilterDtoProfile());
                cfg.AddProfile(new DbFilterProfile());

                cfg.AddProfile(new OrderDetailDtoProfile());
                cfg.AddProfile(new OrderDetailProfile());

                cfg.AddProfile(new OrderDtoProfile());
                cfg.AddProfile(new OrderProfile());

            })).SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper())
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
