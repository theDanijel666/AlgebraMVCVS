using MVC_racuni.Models;

namespace MVC_racuni.Repository
{
    public class RacunRepository
    {
        private static List<Racun> racuni;

        public RacunRepository()
        {
            if (racuni == null)
            {
                racuni=new List<Racun>();
                SimululateDatabase();
            }
        }

        public List<Racun> DohvatRacuni()
        {
            return racuni;
        }

        public Racun RacunPoBroju(int broj_racuna)
        {
            var racun = racuni.Where(r => r.BrojRacuna == broj_racuna).SingleOrDefault();
            return racun;
        }

        public void NapraviNoviRacun(Racun racun)
        {
            racuni.Add(racun);
        }

        public void ObrisiRacun(int broj_racuna)
        {
            racuni.Remove(RacunPoBroju(broj_racuna));
        }

        public void IzmjenaRacuna(Racun racun)
        {
            var stari_racun = racuni.Where(r=>r.Id== racun.Id).SingleOrDefault();
            if(stari_racun != null)
            {
                stari_racun.BrojRacuna = racun.BrojRacuna;
                stari_racun.DatumIzdavanja=racun.DatumIzdavanja;
                stari_racun.Stavke = new List<StavkaRacuna>();
                foreach(var stavka in racun.Stavke)
                {
                    stari_racun.Stavke.Add(stavka);
                }
            }
        }

        private void SimululateDatabase()
        {
            // kreirati objekte klase racun i stavke, te ih popuniti nekim podacima...
            StavkaRacuna s1 = new StavkaRacuna()
            {
                Id=1,
                Naslov="Banana",
                Kolicina=2.34m,
                JedinicanCijena=1.44m
            };
            StavkaRacuna s2 = new StavkaRacuna()
            {
                Id = 2,
                Naslov = "Sladoled",
                Kolicina = 1,
                JedinicanCijena = 2.80m
            };
            StavkaRacuna s3 = new StavkaRacuna()
            {
                Id = 3,
                Naslov = "Šlag",
                Kolicina = 1,
                JedinicanCijena = 1.14m
            };

            Racun r1= new Racun(0);
            r1.DatumIzdavanja=DateTime.Now;
            r1.Stavke.Add(s1);
            r1.Stavke.Add(s2);
            r1.Stavke.Add(s3);

            StavkaRacuna s4 = new StavkaRacuna()
            {
                Id = 4,
                Naslov = "Carsno meso",
                Kolicina = 3.5m,
                JedinicanCijena = 4.2m
            };
            StavkaRacuna s5 = new StavkaRacuna()
            {
                Id = 5,
                Naslov = "Kruh",
                Kolicina = 2,
                JedinicanCijena = 0.90m
            };
            StavkaRacuna s6 = new StavkaRacuna()
            {
                Id = 6,
                Naslov = "Rajčica",
                Kolicina = 2m,
                JedinicanCijena = 2.34m
            };
            StavkaRacuna s7 = new StavkaRacuna()
            {
                Id = 7,
                Naslov = "Osječko Crni Radler",
                Kolicina = 24,
                JedinicanCijena = 1.1m
            };
            Racun r2 = new Racun(r1.BrojRacuna);
            r2.DatumIzdavanja=DateTime.Now;
            r2.Stavke.Add(s4);
            r2.Stavke.Add(s5);
            r2.Stavke.Add(s6);
            r2.Stavke.Add(s7);

            racuni.Add(r1);
            racuni.Add(r2);

        }
    }
}
