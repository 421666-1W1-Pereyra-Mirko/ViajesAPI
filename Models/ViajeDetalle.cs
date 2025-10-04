using System;
using System.Collections.Generic;

namespace ViajesAPI.Models;

public partial class ViajeDetalle
{
    public int Id { get; set; }

    public int ViajeId { get; set; }

    public int ExcursionId { get; set; }

    public int CantidadPersonas { get; set; }

    public decimal Subtotal { get; set; }

    public virtual Excursion Excursion { get; set; } = null!;

    public virtual Viaje Viaje { get; set; } = null!;
}
