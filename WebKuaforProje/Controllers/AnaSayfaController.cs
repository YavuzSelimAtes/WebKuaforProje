using Microsoft.AspNetCore.Mvc;
using WebKuaforProje.Data;

namespace WebKuaforProje.Controllers
{
    public class AnaSayfaController : Controller
    {
        private readonly VeriTabani _context;

        public AnaSayfaController(VeriTabani context)
        {
            _context = context;
        }

        // GET: GirisEkrani
        [HttpGet]
        public IActionResult GirisEkrani()
        {
            return View();
        }

        // POST: GirisEkrani
        [HttpPost]
        public IActionResult GirisEkrani(string kullaniciAdi, string sifre)
        {
            // Kullanıcıyı veritabanında kontrol et
            var kullanici = _context.Kullanicilar
                .FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre);

            if (kullanici != null)
            {
                // Giriş başarılı, yönlendirme yap
                return RedirectToAction("Index", "AnaSayfa");
            }
            else
            {
                // Hata mesajını view'a gönder
                ViewBag.Hata = "Kullanıcı adı veya şifre hatalı!";
                return View();
            }
        }
    }
}
