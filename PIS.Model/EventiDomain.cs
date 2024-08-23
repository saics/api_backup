using System;
using System.Collections.Generic;
using System.Text;

namespace PIS.Model
{
    public class EventiDomain
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int StatusId { get; set; }
        public string Lokacija { get; set; }
        public DateTime DatumPocetka { get; set; }
        public string VrijemePocetka { get; set; }  
        public DateTime DatumZavrsetka { get; set; }
        public string VrijemeZavrsetka { get; set; }  
        public string ImageUrl { get; set; }
        public string Kategorija { get; set; }
        public int BrojMjesta { get; set; }
    }
}

