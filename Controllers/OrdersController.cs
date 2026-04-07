
using Microsoft.AspNetCore.Mvc;
using SmartCart.Api.Services;
using SmartCart.Api.Repositories;

using System;
using System.Collections.Generic;
namespace SmartCart.Api.Controllers
{ 
 [ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{ 
    private readonly CartService _cartService;

public OrdersController(CartService cartService)
{
    _cartService = cartService;
}

[HttpPost("{cartId}/checkout")]
public IActionResult Checkout(int cartId)
{
    try
    {
        var result = _cartService.Checkout(cartId);
        return Ok(result);
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
}



}
}