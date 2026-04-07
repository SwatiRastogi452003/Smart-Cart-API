using System;
using SmartCart.Api.Models;
using System.Linq;
using SmartCart.Api.Repositories;

namespace SmartCart.Api.Services
{
 public class OrderService
{
    private readonly CartRepository _cartRepository;
    private readonly ProductRepository _productRepository;
    private readonly OrderRepository _orderRepository;

    public OrderService(
        CartRepository cartRepository,
        ProductRepository productRepository,
        OrderRepository orderRepository)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    // your logic here
}
}