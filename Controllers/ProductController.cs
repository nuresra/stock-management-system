using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var categories = _context.Categories.ToList(); // Kategorileri veritabanından al
            ViewBag.Categories = new SelectList(categories, "CategoryID", "CategoryName"); // Kategorileri ViewBag'e ekle
            return View(model);
        }

        // POST: Yeni ürün ekleme
        [HttpPost]
        public IActionResult NewProductForm(Product model)
        {
            if (model.CategoryID == 0)
            {
                ModelState.AddModelError("CategoryID", "Kategori seçilmesi zorunludur.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Console.WriteLine("Seçili Kategori ID: " + model.CategoryID);
                    model.Category = _context.Categories.SingleOrDefault(c => c.CategoryID == model.CategoryID);
                    _context.Products.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("NewProductForm");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Seçili Kategori ID: " + model.CategoryID);
                    // Konsolda hata mesajını görebilirsiniz.
                    Console.WriteLine(ex.Message);
                    ModelState.AddModelError("", "Veritabanına kayıt işlemi sırasında bir hata oluştu.");
                }
            }
            else
            {
                Console.WriteLine("Seçili Kategori ID: " + model.CategoryID);
                // Tüm hata mesajlarını konsolda göster
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine($"Hata: {error.ErrorMessage}");
                }
            }

            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryID", "CategoryName");
            return View(model);
        }



        // GET: Stok güncelleme
        public IActionResult UpdateStock(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductID == id);
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
            var product = _context.Products.SingleOrDefault(p => p.ProductID == id);
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
