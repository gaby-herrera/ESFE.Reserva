using System;
using System.Collections.Generic;

namespace ESFE.Reserva.EN;

public partial class TipoHabitacion
{
    public int IdTipoHabitacion { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Imgs { get; set; }

    public int? Capacidad { get; set; }

    public virtual ICollection<Habitacion> Habitacions { get; set; } = new List<Habitacion>();

    public virtual ICollection<Tarifa> Tarifas { get; set; } = new List<Tarifa>();
}
