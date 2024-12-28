using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var subeler = veriTabani.Subeler.Select(s => new { s.Sehir }).ToList();
            ViewBag.Subeler = subeler;
            return View();
        }

        [HttpPost]
        public IActionResult YeniKullanici(Kullanici model)
        {
            if (ModelState.IsValid)
            {
                var yeniKullanici = new Kullanici
                {
                    KullaniciAdi = model.KullaniciAdi,
                    Sifre = model.Sifre,
                    Soyad = model.Soyad,
                    TelefonNo = model.TelefonNo,
                    Rol = model.Rol 
                };

                veriTabani.Kullanicilar.Add(yeniKullanici);
                veriTabani.SaveChanges();


                if (model.Rol == "Personel")
                {
                    var yeniPersonel = new Personel
                    {
                        Id = yeniKullanici.Id, 
                        Subesi = model.Personel.Subesi,
                        UzmanlikAlani = model.Personel.UzmanlikAlani
                    };

                    veriTabani.Personeller.Add(yeniPersonel);
                    veriTabani.SaveChanges();
                }

                return RedirectToAction("KullaniciListesi");
            }
            else Console.WriteLine("Model geçersiz");

            var subeler = veriTabani.Subeler.Select(s => new { s.Sehir }).ToList();
            ViewBag.Subeler = subeler;
            return View(model);
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

            if (string.IsNullOrWhiteSpace(TelefonNo))
            {
                TempData["Mesaj"] = "Telefon numarası boş bırakılamaz!";
                return RedirectToAction("KullaniciListesi");
            }
            var kullanici = veriTabani.Kullanicilar.FirstOrDefault(k => k.Id == Id);

            if (kullanici == null)
            {
                TempData["Mesaj"] = "Kullanıcı bulunamadı!";
                return RedirectToAction("KullaniciListesi");
            }

            kullanici.TelefonNo = TelefonNo;

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

        [HttpPost]
        public IActionResult SifreKontrol([FromBody] sifreKontrol model)
        {
            var admin = veriTabani.Kullanicilar.FirstOrDefault(k => k.Rol == "admin");

            if (admin != null && admin.Sifre == model.Sifre)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Şifre yanlış." });
        }

        [HttpPost]
        public IActionResult AdminGuncelle([FromBody] adminGuncelle model)
        {
            if (ModelState.IsValid)
            {
                var admin = veriTabani.Kullanicilar.FirstOrDefault(k => k.Rol == "admin");

                if (admin != null)
                {
                    admin.KullaniciAdi = model.KullaniciAdi;
                    admin.Ad = model.Ad;
                    admin.Soyad = model.Soyad;
                    admin.TelefonNo = model.TelefonNo;
                    admin.Sifre = model.Sifre;

                    veriTabani.SaveChanges();
                    return Json(new { success = true });
                }

                return Json(new { success = false, message = "Admin bulunamadı." });
            }

            return Json(new { success = false, message = "Geçersiz veri." });
        }


        public class sifreKontrol
        {
            public string Sifre { get; set; }
        }

        public class adminGuncelle
        {
            public string KullaniciAdi { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string TelefonNo { get; set; }
            public string Sifre { get; set; }
        }

    }
}
