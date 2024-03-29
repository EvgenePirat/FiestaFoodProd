using Business.Interfaces;
using Business.Models.Enums;
using Business.Models.Orders.Request;
using Business.Models.Orders.Response;
using Microsoft.AspNetCore.SignalR;

namespace RealTimeHandler.Hubs
{
    public class OrderHub : Hub
    {
        private readonly IOrderService _orderService;

        public OrderHub(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task SendOrder(OrderModel model)
        {
            try
            {
                await Clients.All.SendAsync("ReceiveOrder", model);
            }
            catch (Exception ex)
            {
                await Clients.All.SendAsync("ReceiveOrder", "Error: " + ex.Message);
            }
        }

        public async Task ChangeOrderState(UpdateOrderStateModel model)
        {
            try
            {
                await _orderService.UpdateOrderStateAsync(model, CancellationToken.None);
                await Clients.All.SendAsync("ChangeOrderState", model);
            }
            catch (Exception ex)
            {
                await Clients.All.SendAsync("ChangeOrderState", "Error: " + ex.Message);
            }
        }
    }
}
