using IdentityServer.API1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IdentityServer.API1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        [Authorize(Policy = "ReadProduct")]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var productList = new List<Product>()
            {
                new Product {Id = 1, Name = "Kalem", Price = 30, Stock = 500},
                new Product {Id = 2, Name = "Silgi", Price = 10, Stock = 500},
                new Product {Id = 3, Name = "Defter", Price = 70, Stock = 500},
                new Product {Id = 4, Name = "Kitap", Price = 100, Stock = 500}
            };

            return Ok(productList);
        }

        [Authorize(Policy = "UpdateOrCreate")]
        [HttpPost]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"id'si {id} olan ürün güncellenmiştir");
        }

        [Authorize(Policy = "UpdateOrCreate")]
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            return Ok(product);
        }
    }
}
