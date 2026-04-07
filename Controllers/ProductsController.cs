
using Microsoft.AspNetCore.Mvc;
using SmartCart.Api.Services;
using SmartCart.Api.Repositories;

using System;
using System.Collections.Generic;
 

namespace SmartCart.Api.Controllers
{
    [ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly ProductRepository _repo;
    public ProductsController(ProductRepository repo) => _repo = repo;

    [HttpGet]
    public IActionResult GetProducts() => Ok(_repo.GetAll());
}
}