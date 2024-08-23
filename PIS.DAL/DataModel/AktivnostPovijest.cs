using System;
using System.Collections.Generic;
using System.Text;

namespace PIS.DAL.DataModel
{
    public class AktivnostPovijest
    {
        public int Id { get; set; }
        public int EventPovijestId { get; set; }
        public int OriginalAktivnostId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan VrijemePocetka { get; set; }
        public TimeSpan VrijemeZavrsetka { get; set; }
        public int BrojSudionika { get; set; }
        public decimal ProsjecnaOcjena { get; set; }
        public decimal MedijanOcjena { get; set; }
        public int ModOcjena { get; set; }
        public int BrojOcjena { get; set; }
    }
}
