using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockManagementSystem.Models;
using StockManagementSystem.ViewModels;


namespace StockManagementSystem.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sales = _context.Sales.Include(s => s.Product).ToList();
            return View(sales);
        }

        // GET: Yeni satış ekleme formu
        public IActionResult Create()
        {
            var model = new SaleViewModel
            {
                Products = _context.Products.ToList() // Ürünleri alıyoruz
            };
            return View(model); // Create.cshtml dosyasına model gönderiyoruz
        }

        // POST: Yeni satış ekleme
        [HttpPost]
        public IActionResult Create(SaleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _context.Products.SingleOrDefault(p => p.Id == model.ProductId);
                if (product != null && product.StockQuantity >= model.Quantity)
                {
                    product.StockQuantity -= model.Quantity;
                    var sale = new Sale
                    {
                        ProductId = model.ProductId,
                        Quantity = model.Quantity,
                        TotalPrice = product.Price * model.Quantity,
                        SaleDate = DateTime.Now
                    };
                    _context.Sales.Add(sale);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Yeterli stok bulunmuyor.");
                }
            }

            // Ürün listesini yeniden doldurmak için model.Products'ı tekrar dolduruyoruz
            model.Products = _context.Products.ToList();
            return View(model);
        }
    }
}
