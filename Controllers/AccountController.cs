namespace StockManagementSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using System.Linq;
    using StockManagementSystem.Models;

    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Login sayfasını göster
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Giriş işlemini gerçekleştir
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcıyı veritabanından kontrol et
                var user = _context.Users
                    .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null)
                {
                    // Başarılı giriş - Session'a kullanıcı bilgilerini yaz
                    HttpContext.Session.SetString("Username", user.Username);

                    // Satış ekranına yönlendirme
                    return RedirectToAction("Create", "Sales");
                }
                else
                {
                    // Yanlış kullanıcı adı veya şifre
                    ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre.");
                }
            }

            // Hatalı giriş, login sayfasını tekrar göster
            return View(model);
        }

        // Oturum kapatma
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }

}
