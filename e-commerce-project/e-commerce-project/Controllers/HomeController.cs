using e_commerce_project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace e_commerce_project.Controllers
{
    public class HomeController : Controller
    {
        private static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Description = "This is product 1", Price = "9.9M" },
            new Product { Id = 2, Name = "Product 2", Description = "This is product 2", Price = "19M" },
            new Product { Id = 3, Name = "Product 3", Description = "This is product 3", Price = "30M"}
        };

        public IActionResult Index()
        {
            return View(Products);
        }

        public IActionResult Details(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

