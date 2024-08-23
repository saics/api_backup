using System;
using System.Collections.Generic;
using System.Text;

namespace PIS.Model
{
    public class InteresZaEventDomain
    {
        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public int EventId { get; set; }
        public DateTime DatumInteresa { get; set; }
    }
}
