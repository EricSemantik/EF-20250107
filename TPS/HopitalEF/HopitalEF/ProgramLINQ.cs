using HopitalEF;
using HopitalEF.Model;
using Microsoft.EntityFrameworkCore;

internal class ProgramLINQ
{
    private static void Main(string[] args)
    {
        using (var context = new HopitalEFContext())
        {
            var salles = context.Salles;

            foreach (var salle in salles)
            {
                Console.WriteLine(salle);
            }

            var sallesDispo = context.Salles.Where(s => s.Dispo == true);

            foreach (var salle in sallesDispo)
            {
                Console.WriteLine(salle);
            }

            var consultations = context.Consultations
                .Join(context.Patients,
                        consult => consult.PatientId,
                        patient => patient.Id,
                        (c, p) => new { c, p })
                .Join(context.Medecins,
                        consultPatient => consultPatient.c.MedecinId,
                        medecin => medecin.Id,
                        (cp, m) => new { cp, m })
                .Select(result => new { result.cp.c.DtConsultation, result.cp.c.Motif, PatientNom=result.cp.p.Nom, PatientPrenom = result.cp.p.Prenom, MedecinNom = result.m.Nom, MedecinPrenom = result.m.Prenom });

            foreach (var consult in consultations)
            {
                Console.WriteLine(consult);
            }

            var medecinsSansSalle = context.Medecins.Where(m => m.Salle == null).Count();

            Console.WriteLine (medecinsSansSalle);
        }

    }
}