using System;
using System.Collections.Generic;
using System.Text;

namespace PIS.Model
{
    public class EventPovijestDomain
    {
        public int Id { get; set; }
        public int OriginalEventId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Kategorija { get; set; }
        public string Lokacija { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public int Godina { get; set; }
        public int BrojSudionika { get; set; }
        public decimal ProsjecnaOcjena { get; set; }
        public decimal MedijanOcjena { get; set; }
        public int ModOcjena { get; set; }
        public int BrojOcjena { get; set; }
    }
}
