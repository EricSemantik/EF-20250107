using HopitalEF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalEF
{
    public class HopitalEFContext: DbContext
    {
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Secretaire> Secretaires { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Hopital_EF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Consultation>().ToTable("consultation");

            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.Medecin)
                .WithMany(m => m.Consultations);

            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.Patient)
                .WithMany(p => p.Consultations);

            modelBuilder.Entity<Salle>().ToTable("salle");
            modelBuilder.Entity<Salle>()
                .HasOne(c => c.Medecin)
                .WithOne(m => m.Salle)
                .HasForeignKey<Salle>(s => s.MedecinId);

            modelBuilder.Entity<Personne>().ToTable("personne")
                .HasDiscriminator<string>("type")
                .HasValue<Patient>("patient")
                .HasValue<Medecin>("medecin")
                .HasValue<Secretaire>("secretaire");

            modelBuilder.Entity<Employe>();

            modelBuilder.Entity<Secretaire>();

            modelBuilder.Entity<Medecin>();

            modelBuilder.Entity<Patient>();
        }
    }
}
