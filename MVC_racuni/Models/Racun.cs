using System.ComponentModel;

namespace MVC_racuni.Models
{
    public class Racun
    {
        public int Id { get; set; }

        [DisplayName("Broj računa")]
        public int BrojRacuna { get; set; }

        [DisplayName("Datum izdavanja")]
        public DateTime DatumIzdavanja { get; set; }
        public List<StavkaRacuna> Stavke {  get; set; }

        public Racun()
        {
            this.Stavke=new List<StavkaRacuna>();
        }

        public Racun(int zadnji_broj_racuna)
        {
            this.BrojRacuna = zadnji_broj_racuna + 1;
            Stavke=new List<StavkaRacuna>();
        }

        public decimal Ukupno()
        {
            decimal ukupno = 0;
            foreach(var stavka in Stavke)
            {
                ukupno += stavka.Ukupno();
            }
            return ukupno;
        }
    }
}
