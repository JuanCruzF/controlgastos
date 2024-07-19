using System;
using System.Collections.Generic;

namespace Gastos_MVC.Models;

public partial class TipoDeGasto
{
    public short TipoGastosId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<ListadoDeGasto> ListadoDeGastos { get; set; } = new List<ListadoDeGasto>();
}
