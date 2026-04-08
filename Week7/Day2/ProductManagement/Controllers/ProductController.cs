using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProductManagement.Controllers
{
    public class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    [Route("[controller]")]
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>();

        // GET: Show form and product list
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Products = products;
            return View();
        }

        // POST: Add product to list
        [Route("Index")]
        [HttpPost]
        public IActionResult Index(string productName, decimal price, int quantity)
        {
            Product newProduct = new Product
            {
                ProductName = productName,
                Price = price,
                Quantity = quantity
            };
            
            products.Add(newProduct);
            ViewBag.Products = products;
            
            return View();
        }
    }
}