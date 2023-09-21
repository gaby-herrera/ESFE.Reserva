using System;
using System.Collections.Generic;

namespace ESFE.Reserva.EN;

public partial class Habitacion
{
    public int IdHabitacion { get; set; }

    public short NumeroHabitacion { get; set; }

    public int IdTipoHabitacion { get; set; }

    public int IdEstadoH { get; set; }

    public virtual EstadoH IdEstadoHNavigation { get; set; } = null!;

    public virtual TipoHabitacion IdTipoHabitacionNavigation { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
