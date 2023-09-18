using System;
using System.Collections.Generic;

namespace ESFE.Reserva.EN;

public partial class Tarifa
{
    public int IdTarifa { get; set; }

    public int IdTipoHabitacion { get; set; }

    public int IdTemporada { get; set; }

    public string Temporada { get; set; } = null!;

    public decimal Precio { get; set; }

    public virtual Temporadum IdTemporadaNavigation { get; set; } = null!;

    public virtual TipoHabitacion IdTipoHabitacionNavigation { get; set; } = null!;

    public virtual ICollection<ReservaEN> Reservas { get; set; } = new List<ReservaEN>();
}
