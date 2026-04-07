using System;
using SmartCart.Api.Models;
using System.Linq;
using SmartCart.Api.Repositories;
using SmartCart.Api.DTOs;

namespace SmartCart.Api.Services
{
    public class CartService
{
    private readonly CartRepository _cartRepo;
    private readonly ProductRepository _productRepo;

    private readonly Dictionary<string, Func<decimal, decimal>> _coupons = new()
    {
        {"FLAT50", subtotal => subtotal >= 500 ? 50 : 0},
        {"SAVE10", subtotal => subtotal >= 1000 ? Math.Min(subtotal * 0.10m, 200) : 0}
    };

    public CartService(CartRepository cartRepo, ProductRepository productRepo)
    {
        _cartRepo = cartRepo;
        _productRepo = productRepo;
    }

    public Cart AddOrUpdateItem(int cartId, int productId, int quantity)
    {
        if (quantity <= 0)
            throw new Exception("Quantity must be greater than 0.");

        var cart = _cartRepo.GetById(cartId) ?? throw new Exception("Cart not found.");
        var product = _productRepo.GetById(productId) ?? throw new Exception("Product not found.");

        if (quantity > product.Stock)
            throw new Exception("Requested quantity exceeds stock.");

        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
        if (item == null)
        {
            cart.Items.Add(new CartItem { ProductId = productId, Quantity = quantity });
        }
        else
        {
            item.Quantity = quantity;
        }

        return cart;
    }

    public decimal ApplyCoupon(int cartId, string code)
    {
        var cart = _cartRepo.GetById(cartId) ?? throw new Exception("Cart not found.");
        var subtotal = cart.Items.Sum(i => _productRepo.GetById(i.ProductId)!.Price * i.Quantity);

        if (!_coupons.ContainsKey(code))
            throw new Exception("Invalid coupon code.");

        var discount = _coupons[code](subtotal);
        cart.AppliedCoupon = code;
        return discount;
    }

    public CheckoutResponseDto Checkout(int cartId)
    {
        var cart = _cartRepo.GetById(cartId) ?? throw new Exception("Cart not found.");

        var subtotal = cart.Items.Sum(i => _productRepo.GetById(i.ProductId)!.Price * i.Quantity);
        var discount = 0m;
        if (cart.AppliedCoupon != null && _coupons.ContainsKey(cart.AppliedCoupon))
            discount = _coupons[cart.AppliedCoupon](subtotal);

        // Ensure stock availability before reducing stock
        foreach (var item in cart.Items)
        {
            var product = _productRepo.GetById(item.ProductId)!;
            if (item.Quantity > product.Stock)
                throw new Exception($"Insufficient stock for {product.Name}");
        }

        foreach (var item in cart.Items)
        {
            _productRepo.ReduceStock(item.ProductId, item.Quantity);
        }

        var total = subtotal - discount;
        return new CheckoutResponseDto
        {
            Items = cart.Items,
            Subtotal = subtotal,
            Discount = discount,
            Total = total
        };
    }
}
}