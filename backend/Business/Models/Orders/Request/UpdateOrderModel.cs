﻿using Business.Models.CustomerInfos.Request;

namespace Business.Models.Orders.Request
{
    public class UpdateOrderModel
    {
        public Guid Id { get; set; }
        public UpdateCustomerInfoModel? CustomerInfo { get; set; }
        public IEnumerable<int> ProductIds { get; set; }
    }
}
