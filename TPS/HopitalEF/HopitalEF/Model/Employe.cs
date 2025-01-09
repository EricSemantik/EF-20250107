using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalEF.Model
{
    public abstract class Employe: Personne
    {
        public string? Login { get; set; }
        public string? MotDePasse { get; set; }
        public bool? Pause { get; set; } = false;

        protected Employe()
        {
        }

        protected Employe(Civilite civilite, string nom, string prenom, string login, string motDePasse) : base(civilite, nom, prenom)
        {
            Login = login;
            MotDePasse = motDePasse;
        }
    }
}
