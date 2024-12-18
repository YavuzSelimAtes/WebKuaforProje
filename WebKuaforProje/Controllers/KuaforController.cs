using Microsoft.AspNetCore.Mvc;

namespace WebKuaforProje.Controllers
{
    public class KuaforController : Controller
    {
        public IActionResult Takvimim()
        {
            return View();
        }
    }
}
