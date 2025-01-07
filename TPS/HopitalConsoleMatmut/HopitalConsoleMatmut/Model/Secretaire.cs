using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalConsoleMatmut.Model
{
    public class Secretaire : Employe
    {
        public Secretaire()
        {
        }

        public Secretaire(Civilite civilite, string nom, string prenom, string login, string motDePasse) : base(civilite, nom, prenom, login, motDePasse)
        {
        }
    }
}
