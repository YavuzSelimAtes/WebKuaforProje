using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebKuaforProje.Data;

namespace WebKuaforProje.Controllers
{
    public class SubelerController : Controller
    {

        private readonly VeriTabani veriTabani;

        public SubelerController(VeriTabani veri_Tabani)
        {
            veriTabani = veri_Tabani;
        }


        public IActionResult Subeler(string sehir)
        {
            var sube = veriTabani.Subeler.FirstOrDefault(s => s.Sehir == sehir);

            return View(sube);
        }

        
    }
}
