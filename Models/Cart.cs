
using System;
using System.Collections.Generic;
namespace SmartCart.Api.Models
{ 
       public class Cart
{
    public int Id { get; set; }
    public List<CartItem> Items { get; set; } = new List<CartItem>();
    public string? AppliedCoupon { get; set; }
}
}