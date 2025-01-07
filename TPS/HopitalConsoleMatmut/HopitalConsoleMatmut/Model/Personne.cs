using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalConsole.Model
{
    public abstract class Personne
    {
        public int Id { get; set; }
       
        public Civilite Civilite { get; set; }
        public string Nom { get; set; }

        public string Prenom { get; set; }

        protected Personne()
        {
        }

        protected Personne(Civilite civilite, string nom, string prenom)
        {
            Civilite = civilite;
            Nom = nom;
            Prenom = prenom;
        }
    }
}
