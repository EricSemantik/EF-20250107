using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalConsole.Model
{
    public class Patient : Personne
    {
        public string NumeroSS { get; set; }
        public string MedecinTraitant { get; set; }
        public List<Consultation> Consultations { get; } = new List<Consultation>();

        public Patient()
        {
        }

        public Patient(Civilite civilite, string nom, string prenom, string numeroSS, string medecinTraitant):base(civilite, nom, prenom)
        {
            Nom = nom;
            Prenom = prenom;
            Civilite = civilite;
            NumeroSS = numeroSS;
            MedecinTraitant = medecinTraitant;
        }

        public override string? ToString()
        {
            return $"Salle [{Id} - {Nom} - {Prenom} ]";
        }
    }
}
