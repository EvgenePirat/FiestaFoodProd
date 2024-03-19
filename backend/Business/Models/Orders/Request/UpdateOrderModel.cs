namespace Business.Models.Orders.Request
{
    public class UpdateOrderModel
    {
        public Guid Id { get; set; }
        public IEnumerable<int> DishesId { get; set; }
    }
}
