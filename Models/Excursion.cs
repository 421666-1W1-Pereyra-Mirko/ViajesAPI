using System;
using System.Collections.Generic;

namespace ViajesAPI.Models;

public partial class Excursion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public virtual ICollection<ViajeDetalle> ViajeDetalles { get; set; } = new List<ViajeDetalle>();
}
