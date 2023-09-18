using System;
using System.Collections.Generic;

namespace ESFE.Reserva.EN;

public partial class EstadoH
{
    public int IdEstadoH { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Habitacion> Habitacions { get; set; } = new List<Habitacion>();
}
