using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartCart.Api.Models;

namespace SmartCart.Api.DTOs
{
    public class CheckoutResponseDto {
         public List<CartItem> Items { get; set; } = new();
          public decimal Subtotal { get; set; } public decimal Discount { get; set; } public decimal Total { get; set; } }
}