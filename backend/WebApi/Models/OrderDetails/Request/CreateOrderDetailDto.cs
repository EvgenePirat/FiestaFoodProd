﻿using WebApi.Models.Enums;

namespace WebApi.Models.OrderDetails.Request
{
    public class CreateOrderDetailDto
    {
        public double Sum { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
