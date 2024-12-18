using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
                return RedirectToAction("KullaniciListesi");
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
            return RedirectToAction("KullaniciListesi");
        }

        [HttpPost]
        public IActionResult KullaniciGuncelle(int Id, string TelefonNo)
        {
            // Formdan gelen değerleri kontrol et
            if (string.IsNullOrWhiteSpace(TelefonNo))
            {
                TempData["Mesaj"] = "Telefon numarası boş bırakılamaz!";
                return RedirectToAction("KullaniciListesi");
            }

            // Veritabanında kullanıcıyı bul
            var kullanici = veriTabani.Kullanicilar.FirstOrDefault(k => k.Id == Id);

            if (kullanici == null)
            {
                TempData["Mesaj"] = "Kullanıcı bulunamadı!";
                return RedirectToAction("KullaniciListesi");
            }

            // Telefon numarasını güncelle
            kullanici.TelefonNo = TelefonNo;

            // Değişiklikleri kaydet
            try
            {
                veriTabani.SaveChanges();
                TempData["Mesaj"] = "Telefon numarası başarıyla güncellendi!";
            }
            catch (Exception ex)
            {
                TempData["Mesaj"] = $"Bir hata oluştu: {ex.Message}";
            }

            return RedirectToAction("KullaniciListesi");
        }



        [HttpGet]
        public IActionResult KullaniciListesi()
        {
            var kullanicilar = veriTabani.Kullanicilar.ToList();
            return View(kullanicilar);
        }
    }
}
