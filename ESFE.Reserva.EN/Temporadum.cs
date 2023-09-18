using System;
using System.Collections.Generic;

namespace ESFE.Reserva.EN;

public partial class Temporadum
{
    public int IdTemporada { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Tarifa> Tarifas { get; set; } = new List<Tarifa>();
}
