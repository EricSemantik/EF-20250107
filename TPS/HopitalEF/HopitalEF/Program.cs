using HopitalEF;
using HopitalEF.Model;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new HopitalEFContext())
        {
            var salle206 = new Salle { Nom = "SULTAN", Dispo = true };

            context.Salles.Add(salle206);

            var dupont = new Medecin { Civilite = Civilite.M, Nom = "DUPONT", Prenom = "Pierre", Login = "DUPONTP", MotDePasse = "azerty", Pause = false };
            context.Medecins.Add(dupont);

            context.SaveChanges();
        }
    }
}