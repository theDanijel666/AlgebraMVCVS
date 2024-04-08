using Microsoft.AspNetCore.Mvc;
using MVC_racuni.Models;
using System.Diagnostics;
using MVC_racuni.Repository;

namespace MVC_racuni.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        RacunRepository _repo;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _repo= new RacunRepository();
        }

        //CRUD operacije - Create Read Update Delete

        /// <summary>
        /// Popis svih računa
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<Racun> lista = _repo.DohvatRacuni();
            return View(lista);
        }

        /// <summary>
        /// Kreiranje novog računa:
        /// </summary>
        /// <returns></returns>
        public IActionResult NoviRacun()
        {
            int zadnji = _repo.DohvatRacuni().Count;
            Racun novi=new Racun(zadnji);
            novi.DatumIzdavanja=DateTime.Now;
            return View(novi);
        }

        /// <summary>
        /// Stvaranje novog računa sobzirom na prosljeđene podatke
        /// </summary>
        /// <param name="racun">parametri računa pročitani iz forme</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult NoviRacun(Racun racun)
        {
            _repo.NapraviNoviRacun(racun);
            //return RedirectToAction("Index");
            return RedirectToAction("NovaStavkaRacuna", new { id = racun.BrojRacuna });
        }

        /// <summary>
        /// Akcija za dodavanjae nove stavke na račun
        /// </summary>
        /// <param name="id">Broj računa na koji se treba vezati stavka</param>
        /// <returns></returns>
        public IActionResult NovaStavkaRacuna(int id)
        {
            Racun r = _repo.RacunPoBroju(id);
            if(r == null) return RedirectToAction("Index");
            StavkaRacuna stavka = new StavkaRacuna();
            ViewBag.BrojRacuna = id;
            return View(stavka);
        }

        /// <summary>
        /// Dodavanje stavke na račun, ukoliko je ispravan broj računa prosljeđen.
        /// </summary>
        /// <param name="stavka">Stavka za dodati na račun</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult NovaStavkaRacuna(StavkaRacuna stavka)
        {
            int brojRacuna;
            if(int.TryParse(Request.Form["BrojRacuna"],out brojRacuna))
            {
                Racun racun = _repo.RacunPoBroju(brojRacuna);
                if(racun== null) return RedirectToAction("Index");
                racun.Stavke.Add(stavka);
                return RedirectToAction("NovaStavkaRacuna",new {id=brojRacuna});
            }
            else
            {
                //nemamo broj računa na koji treba dodati stavku, stavka neće biti dodana!
                return RedirectToAction("Index");
            }
        }


        /// <summary>
        /// Akcija za prikazivanje detalja računa
        /// </summary>
        /// <param name="id">Broj računa</param>
        /// <returns></returns>
        public IActionResult DetaljiRacuna(int id)
        {
            Racun r = _repo.RacunPoBroju(id);
            if (r != null)
            {
                return View(r);
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Akcija za brisanje računa
        /// </summary>
        /// <param name="id">Broj računa</param>
        /// <returns></returns>
        public IActionResult ObrisiRacun(int id)
        {
            Racun r = _repo.RacunPoBroju(id);
            if(r != null)
            {
                return View(r);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Potvrđeno brisanje računa
        /// </summary>
        /// <param name="id">Broj računa</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ObrisiRacunPotvrda(int id)
        {
            //Racun r = _repo.RacunPoBroju(id);
            //if (r==null)
            //{
            //    return Error();
            //}
            _repo.ObrisiRacun(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Akcija za izmjenu računa
        /// Nema smisla....
        /// </summary>
        /// <param name="id">Broj računa</param>
        /// <returns></returns>
        public IActionResult IzmjenaRacuna(int id)
        {
            Racun r = _repo.RacunPoBroju(id);
            if (r != null)
            {
                return View(r);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Akcija za storniranje računa
        /// </summary>
        /// <param name="id">Broj računa</param>
        /// <returns></returns>
        public IActionResult StornoRacuna(int id)
        {
            Racun storno = _repo.RacunPoBroju(id);
            if (storno != null)
            {
                Racun novi = new Racun(_repo.DohvatRacuni().Count);
                novi.DatumIzdavanja = DateTime.Now;
                novi.Stavke = new List<StavkaRacuna>();
                foreach(var s in storno.Stavke)
                {
                    StavkaRacuna nova_stavka = new StavkaRacuna();
                    nova_stavka.Naslov = s.Naslov;
                    nova_stavka.Kolicina= - s.Kolicina;
                    nova_stavka.JedinicanCijena = s.JedinicanCijena;
                    novi.Stavke.Add(nova_stavka);
                }
                _repo.NapraviNoviRacun(novi);
            }
            return RedirectToAction("Index");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
