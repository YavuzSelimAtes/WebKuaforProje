using Microsoft.AspNetCore.Mvc;
using WebKuaforProje.Data;

namespace WebKuaforProje.Controllers
{
    public class AdminController : Controller
    {

        private readonly VeriTabani veriTabani;

        public AdminController(VeriTabani veri_Tabani)
        {
            veriTabani = veri_Tabani;
        }

        [HttpGet]
        public IActionResult YeniKullanici()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniKullanici(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                veriTabani.Kullanicilar.Add(kullanici);
                veriTabani.SaveChanges();
                return RedirectToAction("KullaniciListesi","Admin");
            }
            return View(kullanici);
        }

        [HttpPost]
        public IActionResult KullaniciKaldir(int id)
        {
            var kullanici = veriTabani.Kullanicilar.FirstOrDefault(k => k.Id == id);
            if (kullanici != null)
            {
                veriTabani.Kullanicilar.Remove(kullanici);
                veriTabani.SaveChanges();
            }
            return RedirectToAction("KullaniciListesi", "Admin");
        }

        [HttpGet]
        public IActionResult KullaniciListesi()
        {
            var kullanicilar = veriTabani.Kullanicilar.ToList();
            return View(kullanicilar);
        }
    }
}
