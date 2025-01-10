using System;
using System.Collections.Generic;

namespace HopitalEFDBFirst;

public partial class Salle
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public bool Dispo { get; set; }

    public int? MedecinId { get; set; }

    public virtual Personne? Medecin { get; set; }
}
