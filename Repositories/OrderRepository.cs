
using SmartCart.Api.Models;
using System;
using System.Collections.Generic;
namespace SmartCart.Api.Repositories
{
    
    public class OrderRepository
{
    private readonly List<Order> _orders = new();
    private int _nextId = 1;

    public Order Create(Order order)
    {
        order.Id = _nextId++;
        _orders.Add(order);
        return order;
    }

    public Order? GetById(int id) => _orders.FirstOrDefault(o => o.Id == id);
}
}