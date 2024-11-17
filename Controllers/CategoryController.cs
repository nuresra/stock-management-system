using Microsoft.AspNetCore.Mvc;
using StockManagementSystem.Models;

namespace StockManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewCategoryForm()
        {
            var model = new Category();  // Boş bir model oluştur
            return View(model);
        }

        // POST: Yeni ürün ekleme
        [HttpPost]
        public IActionResult NewCategoryForm(Category model)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(model);
                _context.SaveChanges();
                return RedirectToAction("NewCategoryForm");
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
    }
}
