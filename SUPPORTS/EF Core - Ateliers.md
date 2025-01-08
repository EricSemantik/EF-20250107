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