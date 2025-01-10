using System;
using System.Collections.Generic;

namespace HopitalEFDBFirst;

public partial class Consultation
{
    public int Id { get; set; }

    public DateTime DtConsultation { get; set; }

    public string Motif { get; set; } = null!;

    public string? CompteRendu { get; set; }

    public float Tarif { get; set; }

    public int? MedecinId { get; set; }

    public int? PatientId { get; set; }

    public virtual Personne? Medecin { get; set; }

    public virtual Personne? Patient { get; set; }
}
