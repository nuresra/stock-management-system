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
            var sales = _context.Sales
                .Include(s => s.SaleItems)
                .ThenInclude(si => si.Product)
                .ToList();
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

        [HttpPost]
        public IActionResult Create(SaleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sale = new Sale
                {
                    SaleDate = DateTime.Now,
                    SaleItems = model.SaleItems
                        .Select(si =>
                        {
                            var product = _context.Products.SingleOrDefault(p => p.ProductID == si.ProductId);
                            if (product != null && product.StockQuantity >= si.Quantity)
                            {
                                product.StockQuantity -= si.Quantity;
                                // TotalPrice doğrudan ayarlamıyoruz, hesaplanacak
                                return new SaleItem
                                {
                                    ProductId = si.ProductId,
                                    Quantity = si.Quantity,
                                    // TotalPrice hesaplanacak
                                    // Product.Price * Quantity ile toplam fiyatı hesapla
                                };
                            }
                            else
                            {
                                ModelState.AddModelError(string.Empty, "Yeterli stok bulunmuyor.");
                                return null;
                            }
                        })
                        .Where(si => si != null)
                        .ToList()
                };

                if (ModelState.IsValid)
                {
                    _context.Sales.Add(sale);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            // Ürün listesini yeniden doldurmak için model.Products'ı tekrar dolduruyoruz
            model.Products = _context.Products.ToList();
            return View(model);
        }

        // GET: Barkod ile ürün bilgilerini getir
        public IActionResult GetProductByBarcode(string barcode)
        {
            var product = _context.Products.SingleOrDefault(p => p.Barcode == barcode);
            if (product != null)
            {
                return Json(new
                {
                    name = product.ProductName,
                    price = product.Price
                });
            }
            return Json(null);
        }
    }
}
