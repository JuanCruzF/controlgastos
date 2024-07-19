using System;
using System.Collections.Generic;

namespace Gastos_MVC.Models;

public partial class Compradore
{
    public short CompradorId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<ListadoDeGasto> ListadoDeGastos { get; set; } = new List<ListadoDeGasto>();
}
