using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalConsoleMatmut.Model
{
    public class Medecin: Employe
    {
        public Salle Salle { get; set; }
        public List<Consultation> Consultations { get; set; } = new List<Consultation>();   

        public Medecin()
        {
        }

        public Medecin(Civilite civilite, string nom, string prenom, string login, string motDePasse) : base(civilite, nom, prenom, login, motDePasse)
        {
        }
    }
}
