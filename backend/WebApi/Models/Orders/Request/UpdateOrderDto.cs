namespace WebApi.Models.Orders.Request
{
    public class UpdateOrderDto
    {
        public Guid Id { get; set; }
        public IEnumerable<Guid> ProductIds { get; set; }
    }
}
