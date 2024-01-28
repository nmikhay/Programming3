using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using e_commerce_project.Models;

namespace e_commerce_project.Controllers
{
    public class OrderController : Controller
    {
        private static List<Order> Orders = new List<Order>();
        private static int nextOrder = 1;
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Orders = Orders;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.Id = nextOrder++;
                Orders.Add(order);
                ViewBag.Orders = Orders;
                return RedirectToAction("Confirmation", new { id = order.Id });
            }

            ViewBag.Orders = Orders;
            return View(order);
        }

        public IActionResult Confirmation(int id)
        {
            var order = Orders.FirstOrDefault(order => order.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
    }
}

