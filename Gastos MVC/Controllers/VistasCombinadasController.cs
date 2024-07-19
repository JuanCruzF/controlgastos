using Gastos_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Gastos_MVC.Controllers
{
    public class VistasCombinadasController : Controller
    {
        private readonly GastosContext _context;

        public VistasCombinadasController(GastosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> VistaVGastosTotales()
        {
            // Consulta datos desde la base de datos
            var VgastosPorCategoria = await _context.VGastosPorCategoria
                .ToListAsync();

            var VgastosTotale = await _context.VGastosTotales
                .ToListAsync();

            // Crea el ViewModel combinado
            var viewModel = new CombinedViewModel
            {
                Model1 = VgastosPorCategoria,
                Model2 = VgastosTotale
            };

            // Pasa el ViewModel a la vista
            return View(viewModel);
        }
    }
}
