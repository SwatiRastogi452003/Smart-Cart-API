
using System;
using System.Collections.Generic;
namespace SmartCart.Api.Models
{ 
        public class Coupon
{
    public string Code { get; set; }
    public Func<decimal, decimal> Discount { get; set; }
}
}