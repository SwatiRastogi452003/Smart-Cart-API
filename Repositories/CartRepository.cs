
using SmartCart.Api.Models;
using System;
using System.Collections.Generic;
namespace SmartCart.Api.Repositories
{
    public class CartRepository
{
    private readonly List<Cart> _carts = new();
    private int _nextId = 1;

    public Cart Create() 
    {
        var cart = new Cart { Id = _nextId++ };
        _carts.Add(cart);
        return cart;
    }

    public Cart? GetById(int id) => _carts.FirstOrDefault(c => c.Id == id);
}
}