using HopitalEF;
using HopitalEF.Model;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new HopitalEFContext())
        {
            using(var tx = context.Database.BeginTransaction())
            {
                try {
                    var salleOrange = new Salle { Nom = "Orange", Dispo = true };

                    context.Salles.Add(salleOrange);

                    var salleVerte = new Salle { Nom = "Verte", Dispo = true };

                    context.Salles.Add(salleVerte);

                    var salleBleu = new Salle { Nom = "Bleu", Dispo = true };

                    context.Salles.Add(salleBleu);

                    var dupont = new Medecin { Civilite = Civilite.M, Nom = "DUPONT", Prenom = "Pierre", Login = "DUPONTP", MotDePasse = "azerty", Pause = false };
                    context.Medecins.Add(dupont);

                    salleVerte.Medecin = dupont;
                    salleVerte.Dispo = false;

                    var durand = new Patient { Civilite = Civilite.MME, Nom = "DURAND", Prenom = "Ginette", NumeroSS = "2582118521552", MedecinTraitant = "COHEN" };
                    context.Patients.Add(durand);

                    var consultation = new Consultation { DtConsultation = new DateTime(2024, 6, 12, 14, 00, 00), Motif="Suivi ORL", Medecin= dupont, Patient=durand, Tarif = 52, CompteRendu="Tout est ok" };
                    context.Consultations.Add(consultation);

                    var secretaire = new Secretaire { Civilite = Civilite.M, Nom = "GROULT", Prenom = "Benoit", Login = "GROULTB", MotDePasse = "azerty", Pause = true };
                    context.Secretaires.Add(secretaire);
                    context.SaveChanges();

                    tx.Commit();
                } catch (Exception ex)
                {
                    Console.WriteLine("Une erreur s'est produite pendant l'enregistrement des données"); 
                    Console.WriteLine(ex.InnerException.Message);

                    tx.Rollback();
                }
            }
           
        }

    }
}