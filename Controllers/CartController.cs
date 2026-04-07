
using Microsoft.AspNetCore.Mvc;
using SmartCart.Api.Services;
using SmartCart.Api.Repositories;

using System;
using System.Collections.Generic;
using SmartCart.Api.DTOs;
namespace SmartCart.Api.Controllers
{
    [ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{
    private readonly CartService _cartService;
    private readonly CartRepository _cartRepo;

    public CartController(CartService cartService, CartRepository cartRepo)
    {
        _cartService = cartService;
        _cartRepo = cartRepo;
    }

[HttpPost]
public IActionResult CreateCart()
{
    var cart = _cartRepo.Create();
    return Ok(cart);
}
    [HttpPost("items")]
    public IActionResult AddOrUpdateItem([FromBody] AddCartItemDto dto)
    {
        try
        {
            var cart = _cartService.AddOrUpdateItem(dto.CartId, dto.ProductId, dto.Quantity);
            return Ok(cart);
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }

    [HttpGet("{cartId}")]
    public IActionResult GetCart(int cartId)
    {
        var cart = _cartRepo.GetById(cartId);
        return cart != null ? Ok(cart) : NotFound();
    }

    [HttpPost("{cartId}/apply-coupon")]
    public IActionResult ApplyCoupon(int cartId, [FromBody] ApplyCouponDto dto)
    {
        try
        {
            var discount = _cartService.ApplyCoupon(cartId, dto.CouponCode);
            return Ok(new { Discount = discount });
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }

    [HttpPost("{cartId}/checkout")]
    public IActionResult Checkout(int cartId)
    {
        try
        {
            var result = _cartService.Checkout(cartId);
            return Ok(result);
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }
}
}