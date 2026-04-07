using System;
using SmartCart.Api.Models;
using System.Linq;
using SmartCart.Api.Repositories;

namespace SmartCart.Api.Services
{ 
 public class CouponService
{
    public decimal Apply(string code, decimal subtotal)
    {
        if (code == "FLAT50" && subtotal >= 500)
            return 50;

        if (code == "SAVE10" && subtotal >= 1000)
            return Math.Min(subtotal * 0.1m, 200);

        return 0;
    }
}
}