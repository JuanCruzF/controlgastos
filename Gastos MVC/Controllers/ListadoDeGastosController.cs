using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gastos_MVC.Models;

namespace Gastos_MVC.Controllers
{
    public class ListadoDeGastosController : Controller
    {
        private readonly GastosContext _context;

        public ListadoDeGastosController(GastosContext context)
        {
            _context = context;
        }

        // GET: ListadoDeGastoes
        public async Task<IActionResult> Index()
        {
            var gastosContext = _context.ListadoDeGastos.Include(l => l.Comprador).Include(l => l.TipoGastos);
            return View(await gastosContext.ToListAsync());
        }

        // GET: ListadoDeGastoes/Details/5
        public async Task<IActionResult> Details(short? id)

        {

            if (id == null)
            {
                return NotFound();
            }

            var listadoDeGasto = await _context.ListadoDeGastos
                .Include(l => l.Comprador)
                .Include(l => l.TipoGastos)
                .FirstOrDefaultAsync(m => m.ListadoGastosId == id);

            if (!ModelState.IsValid)
            {
                return View(listadoDeGasto);
            }

            if (listadoDeGasto == null)
            {
                return NotFound();
            }

            return View(listadoDeGasto);
        }

        // GET: ListadoDeGastoes/Create
        public IActionResult Create()
        {
            ViewData["CompradorId"] = new SelectList(_context.Compradores, "CompradorId", "Nombre");
            ViewData["TipoGastosId"] = new SelectList(_context.TipoDeGastos, "TipoGastosId", "Nombre");
            return View();
        }

        // POST: ListadoDeGastoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListadoGastosId,CompradorId,TipoGastosId,DetalleCompra,TotalGastado,Fecha")] ListadoDeGasto listadoDeGasto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listadoDeGasto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompradorId"] = new SelectList(_context.Compradores, "CompradorId", "CompradorId", listadoDeGasto.CompradorId);
            ViewData["TipoGastosId"] = new SelectList(_context.TipoDeGastos, "TipoGastosId", "TipoGastosId", listadoDeGasto.TipoGastosId);
            return View(listadoDeGasto);
        }

        // GET: ListadoDeGastoes/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listadoDeGasto = await _context.ListadoDeGastos.FindAsync(id);
            if (listadoDeGasto == null)
            {
                return NotFound();
            }
            ViewData["CompradorId"] = new SelectList(_context.Compradores, "CompradorId", "Nombre", listadoDeGasto.CompradorId);
            ViewData["TipoGastosId"] = new SelectList(_context.TipoDeGastos, "TipoGastosId", "Nombre", listadoDeGasto.TipoGastosId);
            return View(listadoDeGasto);
        }

        // POST: ListadoDeGastoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("ListadoGastosId,CompradorId,TipoGastosId,DetalleCompra,TotalGastado,Fecha")] ListadoDeGasto listadoDeGasto)
        {
            if (id != listadoDeGasto.ListadoGastosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listadoDeGasto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListadoDeGastoExists(listadoDeGasto.ListadoGastosId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompradorId"] = new SelectList(_context.Compradores, "CompradorId", "CompradorId", listadoDeGasto.Comprador);
            ViewData["TipoGastosId"] = new SelectList(_context.TipoDeGastos, "TipoGastosId", "TipoGastosId", listadoDeGasto.TipoGastos);
            return View(listadoDeGasto);
        }

        // GET: ListadoDeGastoes/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listadoDeGasto = await _context.ListadoDeGastos
                .Include(l => l.Comprador)
                .Include(l => l.TipoGastos)
                .FirstOrDefaultAsync(m => m.ListadoGastosId == id);
            if (listadoDeGasto == null)
            {
                return NotFound();
            }

            return View(listadoDeGasto);
        }

        // POST: ListadoDeGastoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var listadoDeGasto = await _context.ListadoDeGastos.FindAsync(id);
            if (listadoDeGasto != null)
            {
                _context.ListadoDeGastos.Remove(listadoDeGasto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListadoDeGastoExists(short id)
        {
            return _context.ListadoDeGastos.Any(e => e.ListadoGastosId == id);
        }
    }
}
