using System;
using System.Collections.Generic;
using System.Text;

namespace PIS.DAL.DataModel
{
    public class DodatniPrijavljeni
    {
        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public int EventId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodenja { get; set; }
    }
}
