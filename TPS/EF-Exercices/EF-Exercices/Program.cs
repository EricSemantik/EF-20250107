using EF_Exercices;

internal class Program
{
    private static void Main(string[] args)
    {
        using (EFContext context = new EFContext())
        {
            var client = new Client { Nom = "SULTAN", Prenom = "Eric" };

            context.Clients.Add(client);

            var adresseClient = new Adresse { Rue = "1 rue de la Paix", CodePostal = "75008", Ville = "Paris" };

            context.Set<Adresse>().Add(adresseClient);

            client.Adresse = adresseClient;


            context.SaveChanges();
        }
    }
}