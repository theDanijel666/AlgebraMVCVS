using Microsoft.AspNetCore.Mvc;
using MVC_osobe.Models;

namespace MVC_osobe.Controllers
{
    public class OsobeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Pozdrav()
        {
            return "Pozdrav svima!";
        }

        public List<int> Brojevi()
        {
            return new List<int>() { 2,6,13,5,773,23,5,2,31 };
        }

        public string Procitaj()
        {
            if(Request.QueryString.Value==String.Empty) return "Nema vrijednosti";
            return "Osoba "+Request.Query["ime"].ToString()+" "+Request.Query["Prezime"].ToString();
        }

        public IActionResult PopisLjudi(int id = 0)
        {
            List<Osobe> ljudi= new List<Osobe>() {
                new Osobe() { Sifra=1, Ime="Nikola", Prezime="Tesla", Godine=34},
                new Osobe() { Sifra=2, Ime="Antun", Prezime="Gustav-Matoš",Godine=30,JePolaznik=false},
                new Osobe() { Sifra=3, Ime="Tin", Prezime="Ujević", Godine=24 },
                new Osobe() { Sifra=4, Ime="Luka", Prezime="Modrić", Godine=38 }
            };

            List<Osobe> lista = new List<Osobe>();
            if (id > 0)
            {
                lista = (from osoba in ljudi where osoba.Sifra == id select osoba).ToList();
            }
            else lista = ljudi;

            ViewBag.BrojOsoba=lista.Count;
            ViewBag.Poruka = "Poruka iz akcije kontrolera :)";

            return View(lista);
        }

        public JsonResult JsonResult()
        {
            Osobe o = new Osobe() { Sifra = 1, Ime = "Nikola", Prezime = "Tesla", Godine = 34 };
            return Json(o);
        }

        [HttpGet]
        public string GetMetoda()
        {
            return "GetMetoda :)";
        }

        [HttpPost]
        public string PostMetoda()
        {
            return "PostMetoda :/";
        }

        [AcceptVerbs("Get","Post","Options")]
        public string UnosNovoga()
        {
            return "Radi preko get i post glagola";
        }

    }
}
