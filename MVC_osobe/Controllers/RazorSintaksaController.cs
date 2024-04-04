using Microsoft.AspNetCore.Mvc;

namespace MVC_osobe.Controllers
{
    public class RazorSintaksaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Primjer()
        {
            return View();
        }

        public IActionResult Multiblok()
        {
            return View();
        }

        public IActionResult TextUBloku()
        {
            return View();
        }

        public IActionResult IFElsePrimjer()
        {
            return View();
        }

        public IActionResult SwitchPrimjer()
        {
            return View();
        }

        public IActionResult ForPrimjer()
        {
            return View();
        }

        public IActionResult WhilePrimjer()
        {
            return View();
        }

        public IActionResult ForeachPrimjer()
        {
            return View();
        }

        public IActionResult Pogled() 
        {
            string p = Request.Query["p"];
            if (!string.IsNullOrEmpty(p))
            {
                return View(p);
            }
            return BadRequest();
        }
    }
}
