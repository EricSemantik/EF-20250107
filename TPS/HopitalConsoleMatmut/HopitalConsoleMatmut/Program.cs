using HopitalConsoleMatmut;
using HopitalConsoleMatmut.Model;
using HopitalConsoleMatmut.Repository;
using HopitalConsoleMatmut.Repository.Memory;
using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel;
using System.Data.Common;
using System.Numerics;

internal class Program
{
    static Employe? connected = null;

    static bool enPause = false;
    static void Main()
    {
        //Salle salle = new Salle { Nom = "Salle 2", Dispo = true };

        //HopitalApplication.GetInstance().SalleRepo.Add(salle);



        try
        {
            MenuPrincipal();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void MenuPrincipal()
    {
        Console.WriteLine("\nAppli Hopital :");
        Console.WriteLine("1- Se connecter");
        Console.WriteLine("2- Stop");

        int choix = 0;
        try
        {
            choix = SaisieInt("Choisir un menu");

            switch (choix)
            {
                case 1: SeConnecter(); break;
                case 2: System.Environment.Exit(0); break;
            }
        } catch(ArgumentException ex)
        {
            Console.WriteLine($"Erreur argument {ex.Message}");
        } catch(Exception ex)
        {
            Console.WriteLine("Autre erreur");
        } 
       

        MenuPrincipal();
    }

    public static void SeConnecter()
    {
        string? login = SaisieString("Saisir login");
        string? password = SaisieString("Saisir password");
        connected = HopitalApplication.GetInstance().EmployeRepo.Authentification(login, password);

        if (connected == null)
        {
            Console.WriteLine("Identifiants invalides");
        }
        else if (connected is Medecin) 
		{
            if (((Medecin)connected).Salle?.Id == null)
            {
                //List<Salle> salles = HopitalApplication.GetInstance().SalleRepo.GetAllDispo();

                //foreach(Salle item in salles)
                //{
                //    Console.WriteLine(item);
                //}

                var salles = HopitalApplication.GetInstance().SalleRepo.GetAllDispo();

                salles.ForEach(item => Console.WriteLine(item));
                
                //foreach (var item in salles.Select((value, pos) => new { value, pos})) { 
                //    Console.WriteLine($"Salle: {item.value} à la position {item.pos}");
                //}

                //for(int i = 0; i< salles.Count; i++)
                //{
                //    var item = new { value= salles[i], pos=i };
                //    Console.WriteLine($"Salle: {item.value} à la position {item.pos}");
                //}
                

                int idSalle = SaisieInt("Dans quelle salle ?");
                Salle salle = HopitalApplication.GetInstance().SalleRepo.GetById(idSalle);
                salle.Dispo = false;
                ((Medecin)connected).Salle = salle;
            }
            MenuMedecin();
        }

        else if (connected is Secretaire) 
		{
            if (enPause)
            {
                MenuSecretairePause();
            }
            else
            {
                MenuSecretaire();
            }
        }

    }

    public static void MenuSecretaire()
    {
        Console.WriteLine("\nMenu Secretaire");
        Console.WriteLine("1- Ajouter un patient dans la file d'attente");
        Console.WriteLine("2- Afficher la file d'attente");
        Console.WriteLine("3- Afficher les anciennes visites d'un patient");
        Console.WriteLine("4- Partir en pause");
        Console.WriteLine("5- Se deconnecter");

        int choix = SaisieInt("Choisir menu");

        switch (choix)
        {
            case 1: AjouterPatient(); break;
            case 2: AfficherFile(); break;
            case 3: AfficherVisites(); break;
            case 4: PartirPause(); break;
            case 5: SeDeconnecter(); break;
        }

        MenuSecretaire();
    }

    public static void AjouterPatient()
    {
        int idPatient = SaisieInt("Saisir l'id du patient");
        Patient? p = HopitalApplication.GetInstance().PatientRepo.GetById(idPatient);
        if (p == null)
        {
            Console.WriteLine("Creation d'un nouveau patient :");
            string nom = SaisieString("Saisir nom");
            string prenom = SaisieString("Saisir prenom");
            p = new Patient { Nom = nom, Prenom = prenom };
            HopitalApplication.GetInstance().PatientRepo.Add(p);
            Console.WriteLine("Le patient " + p + " a ete ajoute en bdd");
        }
        HopitalApplication.GetInstance().FileAttente.Patients.Add(p);
        Console.WriteLine("Le patient " + p + " est dans la file d'attente");
    }

    public static void AfficherFile()
    {
        if (HopitalApplication.GetInstance().FileAttente.Patients.Count == 0)
        {
            Console.WriteLine("Aucun patient dans la file d'attente");
        }
        foreach (Patient p in HopitalApplication.GetInstance().FileAttente.Patients)
        {
            Console.WriteLine(p);
        }
    }

    public static void AfficherVisites()
    {
        int idPatient = SaisieInt("Saisir l'id du Patient");
        List<Consultation> consultations = HopitalApplication.GetInstance().ConsultationRepo.GetAllByPatient(idPatient);
        if (consultations.Count == 0)
        {
            Console.WriteLine("Pas de visite a ce jour");
        }
        foreach (Consultation c in consultations)
        {
            Console.WriteLine(c);
        }
    }

    public static void PartirPause()
    {
        enPause = true;
        MenuSecretairePause();
    }

    public static void MenuSecretairePause()
    {
        Console.WriteLine("\nMenu Secretaire pause");
        Console.WriteLine("1- Revenir de pause");
        Console.WriteLine("2- Se deconnecter");

        int choix = SaisieInt("Choisir menu");

        switch (choix)
        {
            case 1: RevenirPause(); break;
            case 2: SeDeconnecter(); break;
        }

        MenuSecretairePause();

    }

    public static void RevenirPause()
    {
        enPause = false;
        
        MenuSecretaire();
    }

    public static void SeDeconnecter()
    {
        connected = null;
        MenuPrincipal();
    }

    public static void MenuMedecin()
    {
        Console.WriteLine("\nMenu Medecin");
        Console.WriteLine("1- Recevoir un patient de la file d'attente");
        Console.WriteLine("2- Afficher la file d'attente");
        Console.WriteLine("3- Se deconnecter");

        int choix = SaisieInt("Choisir menu");

        switch (choix)
        {
            case 1: RecevoirPatient(); break;
            case 2: AfficherFile(); break;
            case 3: SeDeconnecter(); break;
        }

        MenuMedecin();
    }

    public static void RecevoirPatient()
    {
        if (HopitalApplication.GetInstance().FileAttente.Patients.Count == 0)
        {
            Console.WriteLine("Aucun patient dans la file d'attente");
        }
        else
        {
            Medecin m = (Medecin)connected;
            Patient p = HopitalApplication.GetInstance().FileAttente.Patients.First();
            HopitalApplication.GetInstance().FileAttente.Patients.RemoveAt(0);
            Console.WriteLine("Passage du patient : " + p);
            Consultation v = new Consultation() { Patient = p, Medecin = m };
            m.Consultations.Add(v);
        }
    }

    public static string? SaisieString(string msg)
    {
        Console.WriteLine(msg);
        return Console.ReadLine();
    }

    public static int SaisieInt(string msg)
    {
        Console.WriteLine(msg);
        int nb = 0;
        try
        {
            string? str = Console.ReadLine();
            if(String.IsNullOrEmpty(str))
            {
                str = null;
            }

            nb = Int32.Parse(str);
        } catch(FormatException ex) 
        {
            Console.WriteLine("Erreur lors de la lecture un entier");
            throw ex;
        } finally
        {
            Console.WriteLine("On est passé dans SaisieInt");
        }

        return nb;

    }

    public static double SaisieDouble(string msg)
    {
        Console.WriteLine(msg);
        return Double.Parse(Console.ReadLine());
    }

    public static bool SaisieBoolean(string msg)
    {
        Console.WriteLine(msg);
        return Boolean.Parse(Console.ReadLine());
    }

    public static void ExempleADO()
    {
        using (var connection = HopitalApplication.GetInstance().GetConnection())
        {
            connection.Open();
            //connection.ChangeDatabase("Hopital_ADO");
            SqlCommand commandeLecture = connection.CreateCommand();
            commandeLecture.CommandText = "SELECT Id, Nom, Dispo FROM [dbo].[Salles]";
            using (DbDataReader reader = commandeLecture.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("\tId: " + reader["Id"]
                        + " Nom: " + reader["Nom"]
                        + " Dispo: " + reader["Dispo"]);
                }
            }
        }
    }
}