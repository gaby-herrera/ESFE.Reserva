using System;
using System.Collections.Generic;

namespace ESFE.Reserva.EN;

public partial class EstadoR
{
    public int IdEstadoR { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<ReservaEN> Reservas { get; set; } = new List<ReservaEN>();
}
