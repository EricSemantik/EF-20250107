using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalEF.Model
{
    public class Consultation
    {
        public int Id { get; set; } 
        public DateTime DtConsultation { get; set; }
        public string Motif { get; set; }
        public string? CompteRendu { get; set; }
        public float Tarif { get; set; }
        public Patient? Patient { get; set; }
        public Medecin? Medecin { get; set; }



    }
}
