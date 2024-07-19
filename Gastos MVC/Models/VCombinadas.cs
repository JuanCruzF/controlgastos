namespace Gastos_MVC.Models
{
    public class VGastosPorCategoria
    {
        public string? Comprador { get; set; }

        public string? TipoGasto { get; set; }

        public long? TotalGastado { get; set; }
    }

    public class VGastosTotale
    {
        public short CompradorId { get; set; }

        public string? Nombre { get; set; }

        public long? TotalGastado { get; set; }
    }
    // Definir el ViewModel
    public class CombinedViewModel
    {
        public List<VGastosPorCategoria> Model1 { get; set; }
        public List<VGastosTotale> Model2 { get; set; }
    }
}
