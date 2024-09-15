using Microsoft.AspNetCore.Mvc;
using StockManagementSystem.Models;
using System.Linq;

namespace StockManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ürün listeleme
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // GET: Yeni ürün ekleme formu
        public IActionResult NewProductForm()
        {
            var model = new Product();  // Boş bir model oluştur
            return View(model);
        }

        // POST: Yeni ürün ekleme
        [HttpPost]
        public IActionResult NewProductForm(Product model)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(model);
                _context.SaveChanges();
                return RedirectToAction("NewProductForm");
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);  // Konsolda hataları görebilirsiniz.
                }
                return View(model);
            }
    
            return View(model);
        }

        // GET: Stok güncelleme
        public IActionResult UpdateStock(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Stok güncelleme
        [HttpPost]
        public IActionResult UpdateStock(int id, int stockIncrement)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.StockQuantity += stockIncrement;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

      

    }
}
