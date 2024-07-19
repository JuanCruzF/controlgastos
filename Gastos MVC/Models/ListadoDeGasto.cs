using System;
using System.Collections.Generic;

namespace Gastos_MVC.Models;

public partial class ListadoDeGasto
{
    public short ListadoGastosId { get; set; }

    public short? CompradorId { get; set; }

    public short? TipoGastosId { get; set; }

    public string DetalleCompra { get; set; } = null!;

    public long TotalGastado { get; set; }

    public DateOnly Fecha { get; set; }

    public virtual Compradore? Comprador { get; set; }

    public virtual TipoDeGasto? TipoGastos { get; set; }
}
