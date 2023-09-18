using System;
using System.Collections.Generic;

namespace ESFE.Reserva.EN;

public partial class ReservaEN
{
    public int IdReserva { get; set; }

    public int IdEstadoR { get; set; }

    public int IdCliente { get; set; }

    public int IdHabitacion { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public int IdTarifa { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual EstadoR IdEstadoRNavigation { get; set; } = null!;

    public virtual Habitacion IdHabitacionNavigation { get; set; } = null!;

    public virtual Tarifa IdTarifaNavigation { get; set; } = null!;
}
