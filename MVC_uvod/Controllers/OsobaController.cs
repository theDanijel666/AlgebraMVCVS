using Microsoft.AspNetCore.Mvc;
using MVC_uvod.Models;

namespace MVC_uvod.Controllers
{
    public class OsobaController : Controller
    {
        [HttpGet]
        public IActionResult Index(Osoba o)
        {
            ViewBag.Ime = "Moje ime :)";
            //Osoba o = new Osoba()
            //{
            //    Ime = "Nikola",
            //    Prezime = "Tesla",
            //    DatumRodjenja = new DateTime(1867, 6, 21)
            //};
            return View(o);
        }

        [HttpPost]
        public IActionResult OsobaPost()
        {
            var formString = Request.Form;

            Osoba nova_osoba= new Osoba();
            nova_osoba.Ime = formString["Ime"];
            nova_osoba.Prezime = formString["Prezime"];
            nova_osoba.DatumRodjenja = DateTime.Parse(formString["DatumRodjenja"]);

            return View("Index", nova_osoba);
        }
    }
}
