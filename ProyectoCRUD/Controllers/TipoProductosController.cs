using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoCRUD.Models.DAL;
using ProyectoCRUD.Models.Entities;

namespace ProyectoCRUD.Controllers
{
    public class TipoProductosController : Controller
    {
        private readonly DbContextProyecto _context;

        public TipoProductosController(DbContextProyecto context)
        {
            _context = context;
        }

        // GET: TipoProductos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoProductos.ToListAsync());
        }

        // GET: TipoProductos/Details/5
        public async Task<IActionResult> DetallesTipoP(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProducto = await _context.TipoProductos
                .FirstOrDefaultAsync(m => m.TipoProductoId == id);
            if (tipoProducto == null)
            {
                return NotFound();
            }

            return View(tipoProducto);
        }

        // GET: TipoProductos/Create
        public IActionResult CrearTipoP()
        {
            return View();
        }

        // POST: TipoProductos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearTipoP([Bind("TipoProductoId,Nombre")] TipoProducto tipoProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProducto);
        }

        // GET: TipoProductos/Edit/5
        public async Task<IActionResult> EditarTipoP(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProducto = await _context.TipoProductos.FindAsync(id);
            if (tipoProducto == null)
            {
                return NotFound();
            }
            return View(tipoProducto);
        }

        // POST: TipoProductos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarTipoP(int id, [Bind("TipoProductoId,Nombre")] TipoProducto tipoProducto)
        {
            if (id != tipoProducto.TipoProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoProductoExists(tipoProducto.TipoProductoId))
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
            return View(tipoProducto);
        }

        // GET: TipoProductos/Delete/5
        public async Task<IActionResult> EliminarTipoP(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProducto = await _context.TipoProductos
                .FirstOrDefaultAsync(m => m.TipoProductoId == id);
            if (tipoProducto == null)
            {
                return NotFound();
            }

            _context.TipoProductos.Remove(tipoProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        private bool TipoProductoExists(int id)
        {
            return _context.TipoProductos.Any(e => e.TipoProductoId == id);
        }
    }
}
