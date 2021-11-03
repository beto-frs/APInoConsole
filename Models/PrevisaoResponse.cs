using System.Collections.Generic;

namespace ConsultandoPrevisao.Models
{
    public class PrevisaoResponse
    {

        public List<Dado> dados { get; set; }
        public Local local { get; set; }
        public long arquivo { get; set; }
    }

    public class Dado
    {
        public string dia { get; set; }
        public string mes { get; set; }
        public string ano { get; set; }
        public string rodada { get; set; }
        public string minima { get; set; }
        public string maxima { get; set; }
        public string vento { get; set; }
        public string direcao { get; set; }
        public string tipo { get; set; }
        public string prec { get; set; }
    }

    public class Local
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string formattedAddress { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string countryCode { get; set; }
        public string neighbourhood { get; set; }
        public string provider { get; set; }
    }
}