using System;
using System.Collections.Generic;

namespace HopitalEFDBFirst;

public partial class Personne
{
    public int Id { get; set; }

    public int? Civilite { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Login { get; set; }

    public string? MotDePasse { get; set; }

    public bool? Pause { get; set; }

    public string? NumeroSs { get; set; }

    public string? MedecinTraitant { get; set; }

    public virtual ICollection<Consultation> ConsultationMedecins { get; set; } = new List<Consultation>();

    public virtual ICollection<Consultation> ConsultationPatients { get; set; } = new List<Consultation>();

    public virtual Salle? Salle { get; set; }
}
