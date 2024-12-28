using Microsoft.AspNetCore.Mvc;
using WebKuaforProje.Data;

namespace WebKuaforProje.Controllers
{
    public class AnaSayfaController : Controller
    {
        private readonly VeriTabani veriTabani;

        public AnaSayfaController(VeriTabani veri_Tabani)
        {
            veriTabani = veri_Tabani;
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
            var kullanici = veriTabani.Kullanicilar
                .FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre);

            if (kullanici != null)
            {
                if (kullanici.Rol == "admin")
                    return RedirectToAction("YeniKullanici", "Admin");
                else if (kullanici.Rol == "Müşteri")
                    return RedirectToAction("Randevu", "Musteri");
                else if (kullanici.Rol == "Personel")
                    return RedirectToAction("Takvimim", "Kuafor");
                else return RedirectToAction("GirisEkrani", "AnaSayfa");
            }
            else
            {
                ViewBag.Hata = "Kullanıcı adı veya şifre hatalı!";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Kaydol(string ad, string soyad, string tel, string kullaniciAdi, string sifre)
        {
            var yeniMusteri = new Kullanici
            {
                Ad = ad,
                Soyad = soyad,
                TelefonNo = tel,
                KullaniciAdi = kullaniciAdi,
                Sifre = sifre,
                Rol = "Müşteri"
            };

            veriTabani.Kullanicilar.Add(yeniMusteri);
            veriTabani.SaveChanges();

            return RedirectToAction("GirisEkrani"); // Kaydolduktan sonra anasayfaya yönlendir
        }

        public IActionResult SubelerimizIstanbul()
        {
            return View();
        }

        public IActionResult SubelerimizAnkara()
        {
            return View();
        }

        public IActionResult SubelerimizSakarya()
        {
            return View();
        }

        public IActionResult SubelerimizTokat()
        {
            return View();
        }
    }
}
