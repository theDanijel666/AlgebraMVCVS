namespace MVC_racuni.Models
{
    public class StavkaRacuna
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public decimal Kolicina { get; set; }
        public decimal JedinicanCijena { get; set; }

        public decimal Ukupno()
        {
            return Kolicina * JedinicanCijena;
        }
    }
}
