using Microsoft.AspNetCore.Mvc;
using KrishiBazaarProject.Data;
using KrishiBazaarProject.Models;

namespace KrishiBazaarProject.Controllers
{
    public class FarmerDashboardController : Controller
    {
        private readonly AppDbContext _context;

        public FarmerDashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            string userId = HttpContext.Session.GetString("UserID");
            var products = _context.Products.Where(p => p.FarmerID == userId).ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine("wwwroot/images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
                product.Photos = "/images/" + fileName;
            }

            string userId = HttpContext.Session.GetString("UserID");
            product.FarmerID = userId;
            product.UploadDate = DateTime.Now;
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product, IFormFile imageFile)
        {
            var existingProduct = _context.Products.Find(product.ProductID);
            if (existingProduct == null) return NotFound();

            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine("wwwroot/images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
                existingProduct.Photos = "/images/" + fileName;
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.PricePerUnit = product.PricePerUnit;
            existingProduct.AvailableQuantity = product.AvailableQuantity;

            _context.Products.Update(existingProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}