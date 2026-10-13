
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Product_Lab_6.Models;

namespace Product_Lab_6.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products =
            new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Category = "Electronics",
                Price = 55000,
                Description = "High-performance laptop",
                ImageUrl = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?auto=format&fit=crop&w=600&q=80"
            },

            new Product
            {
                Id = 2,
                Name = "Headphones",
                Category = "Accessories",
                Price = 1500,
                Description = "Wireless headphones",
                ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?auto=format&fit=crop&w=600&q=80"
            },

            new Product
            {
                Id = 3,
                Name = "Keyboard",
                Category = "Accessories",
                Price = 900,
                Description = "Computer keyboard",
                ImageUrl = "https://images.unsplash.com/photo-1587829741301-dc798b83add3?auto=format&fit=crop&w=600&q=80"
            },

            new Product
            {
                Id = 4,
                Name = "Smartphone",
                Category = "Electronics",
                Price = 18000,
                Description = "Modern smartphone",
                ImageUrl = "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?auto=format&fit=crop&w=600&q=80"
            },

            new Product
            {
                Id = 5,
                Name = "Smartwatch",
                Category = "Wearables",
                Price = 3500,
                Description = "Smart fitness watch",
                ImageUrl = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?auto=format&fit=crop&w=600&q=80"
            },

            new Product
            {
                Id = 6,
                Name = "Camera",
                Category = "Photography",
                Price = 32000,
                Description = "Digital photography camera",
                ImageUrl = "https://images.unsplash.com/photo-1516035069371-29a1b244cc32?auto=format&fit=crop&w=600&q=80"
            }
        };

        private static int nextId = 7;

        // Display all products
        public ActionResult Index()
        {
            return View(products);
        }

        // Display product details
        public ActionResult Details(int id)
        {
            var product = products.FirstOrDefault(
                p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // Show create form
        public ActionResult Create()
        {
            return View();
        }

        // Save new product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            product.Id = nextId++;
            products.Add(product);

            return RedirectToAction("Index");
        }

        // Show edit form
        public ActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(
                p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // Update product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product updated)
        {
            if (!ModelState.IsValid)
                return View(updated);

            var product = products.FirstOrDefault(
                p => p.Id == updated.Id);

            if (product == null)
                return HttpNotFound();

            product.Name = updated.Name;
            product.Category = updated.Category;
            product.Price = updated.Price;
            product.Description = updated.Description;
            product.ImageUrl = updated.ImageUrl;

            return RedirectToAction("Index");
        }

        // Show delete confirmation
        public ActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(
                p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // Delete product
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(
                p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            products.Remove(product);

            return RedirectToAction("Index");
        }
    }
}
