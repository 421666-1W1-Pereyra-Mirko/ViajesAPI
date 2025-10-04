using System;
using System.Collections.Generic;

namespace ViajesAPI.Models;

public partial class Viaje
{
    public int Id { get; set; }

    public string Destino { get; set; } = null!;

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public decimal PrecioTotal { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<ViajeDetalle> ViajeDetalles { get; set; } = new List<ViajeDetalle>();
}
