using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HopitalEFDBFirst;

public partial class HopitalEfContext : DbContext
{
    public HopitalEfContext()
    {
    }

    public HopitalEfContext(DbContextOptions<HopitalEfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Consultation> Consultations { get; set; }

    public virtual DbSet<Personne> Personnes { get; set; }

    public virtual DbSet<Salle> Salles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Hopital_EF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consultation>(entity =>
        {
            entity.ToTable("consultation");

            entity.HasIndex(e => e.MedecinId, "IX_consultation_MedecinId");

            entity.HasIndex(e => e.PatientId, "IX_consultation_PatientId");

            entity.HasOne(d => d.Medecin).WithMany(p => p.ConsultationMedecins).HasForeignKey(d => d.MedecinId);

            entity.HasOne(d => d.Patient).WithMany(p => p.ConsultationPatients).HasForeignKey(d => d.PatientId);
        });

        modelBuilder.Entity<Personne>(entity =>
        {
            entity.ToTable("personne");

            entity.Property(e => e.NumeroSs).HasColumnName("NumeroSS");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Salle>(entity =>
        {
            entity.ToTable("salle");

            entity.HasIndex(e => e.MedecinId, "IX_salle_MedecinId")
                .IsUnique()
                .HasFilter("([MedecinId] IS NOT NULL)");

            entity.HasOne(d => d.Medecin).WithOne(p => p.Salle).HasForeignKey<Salle>(d => d.MedecinId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
