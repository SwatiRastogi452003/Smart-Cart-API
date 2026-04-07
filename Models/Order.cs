
using System;
using System.Collections.Generic;
namespace SmartCart.Api.Models
{  public class Order
{
    public int Id { get; set; }
    public List<CartItem> Items { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }
}
}