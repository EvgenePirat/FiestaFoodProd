﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.OrdemItems.Request
{
    public class UpdateOrderItemDto
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string? Comment { get; set; }
    }
}
