using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Exercices
{
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresse>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Adresse>().ToTable("adress");
            
            modelBuilder.Entity<Adresse>().Property(a => a.Id).HasColumnName("id");
            modelBuilder.Entity<Adresse>().HasKey(a => a.Id);
            modelBuilder.Entity<Adresse>().Property(a => a.Rue).HasColumnName("street").HasMaxLength(255);
            modelBuilder.Entity<Adresse>().Property(a => a.CodePostal).HasColumnName("zipcode").HasMaxLength(10);
            modelBuilder.Entity<Adresse>().Property(a => a.Ville).HasColumnName("city").HasMaxLength(100);
        }
    }
}
