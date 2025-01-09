using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalEF.Model
{
    public class Salle
    {
        public int Id { get; set; } 
        public string Nom { get; set; }
        public bool Dispo { get; set; }
        public int? MedecinId { get; set; } 
        public Medecin? Medecin { get; set; }

        public override string? ToString()
        {
            return $"Salle [{Id} - {Nom} - {Dispo} ]";
        }
    }
}
