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

            context.SaveChanges();
        }
    }
}