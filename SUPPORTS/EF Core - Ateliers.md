# EF Core - Ateliers

## Atelier 1

- Créer un projet application Console (avec .NET 6) EF-Exercices

- Rajouter les packages Nuget (via l'assistant graphique) :

  - Microsoft.EntityFramewoworkCore en 7.0.20
  - Microsoft.EntityFramewoworkCore.SqlServer en 7.0.20

- Rajouter le package Nuget (via la console Nuget) :

  - ```
    Install-Package Microsoft.EntityFrameworkCore.Tools -Version 7.0.20
    ```

- Créer une classe Client avec :

```c#
public class Client
{
    public int ClientId { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
}
```

- Créer la classe EFContext qui hérite de DbContext 

```c#
public class EFContext : DbContext
{
    public DbSet<Client> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=EF_Exo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
```

- Modifier la classe Program pour créer un client dans la BDD via EF

```c#
private static void Main(string[] args)
{
    using (EFContext context = new EFContext())
    {
        var client = new Client { Nom = "SULTAN", Prenom = "Eric" };

        context.Clients.Add(client);

        context.SaveChanges();
    }
}
```

- Exécuter les commandes de création des migrations et mise à jour de BDD

```
Add-Migration Initial
```

```
Update-Database
```

## Atelier 2

- En utilisant les annotations, effectuer un mapping avec pour cible :

```sql
CREATE TABLE customer (
	id int NOT NULL IDENTITY PRIMARY KEY,
	lastname NVARCHAR(max),
	firstname NVARCHAR(max)
)
```

- Pensez à créer la nouvelle table dans la BDD (Add-Migration ...)
- Que remarques-vous dans la BDD ?

## Atelier 3

- Créer une classe Adresse

```c#
public class Adresse {
    public int Id { get ; set ;}
    public string Rue {get;set;}
    public string CodePostal { get ; set ;}
    public string Ville { get ; set ;}
}
```

- En utilisant la Fluent API, effectuer un mapping avec pour cible :

```sql
CREATE TABLE adress (
	id int NOT NULL IDENTITY PRIMARY KEY,
	street NVARCHAR(max),
	zipcode NVARCHAR(max),
	city NVARCHAR(max)
)
```

- Modifier le Program et le EFContext pour pouvoir créer une Adresse en BDD

## Atelier 4

- Modifier le mapping pour arriver à ce schéma de BDD

```sql
CREATE TABLE customer (
	id int NOT NULL IDENTITY PRIMARY KEY,
	lastname NVARCHAR(100),
	firstname NVARCHAR(100) NULL,
	email NVARCHAR(255) NULL UNIQUE,
	adress_id INT NULL,
	FOREIGN KEY (adress_id) REFERENCES adress(id)
)

CREATE TABLE adress (
	id int NOT NULL IDENTITY PRIMARY KEY,
	street NVARCHAR(255) NULL,
	zipcode NVARCHAR(10) NULL,
	city NVARCHAR(100) NULL
)
```

- Modifier le Program pout vérifier le bon fonctionnement

## Atelier 5

- Créer une classe Compte avec :

```c#
public class Compte
	public int CompteId { get ; set ;}
	public decimal Solde { get ; set ;}
	public int ClientId { get ; set ;}
	public Client Client { get ; set ;}
}
```

- Modifier la classe Client en y ajoutant une liste de comptes :

```c#
public List<Compte> Comptes { get ; set ;}
```

- Effectuer le mapping en Fluent API entre Compte.Client et Client.Comptes
- Modifier le Program pour créer deux comptes et les associer au client préalablement créé

## Atelier 6

- Créer un projet en vue d'effectuer un Scaffolding

```
Scaffold-DbContext -Connection "Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Hopital_EF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" -Provider Microsoft.EntityFrameworkCore.SqlServer -Project HopitalEFDBFirst
```

## Atelier 7

Dans le projet HopitalEF, modifier le Program pour exécuter au sein d'une transaction :

1. Créer trois salles 
2. Créer deux médecin et associer un des deux à une salle
3. Créer un patient 
4. Créer une consultation et l'associer au médecin qui a une salle et au patient
5. Créer une secrétaire

## Atelier 8

Dans le projet HopitalEF, créer une classe qui contiendra un Main (comme Program) :

- Lister toutes les salles
- Lister toutes les salles disponibles
- Lister pour toutes les consultations : 
  - date de consultation
  - motif
  - nom et prénom du patient
  - nom et prénom du médecin
- Compter tous les Médecins qui n'ont pas de salle associé

## Atelier 9

Reprendre les Interfaces du projet HopitalConsoleMatmut:

- IRepository et ISalleRepository 
- Implémenter la classe SalleRepositoryEF qui utilisera HopitalEFContext 
