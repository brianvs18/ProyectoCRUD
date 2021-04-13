using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoCRUD.Models.Abstract;
using ProyectoCRUD.Models.DAL;
using ProyectoCRUD.Models.Entities;

namespace ProyectoCRUD.Controllers
{
    public class TipoProductosController : Controller
    {
        private readonly ITipoProductoServices _tipoProductoServices;

        public TipoProductosController(ITipoProductoServices tipoProductoServices)
        {
            _tipoProductoServices = tipoProductoServices;
        }

        // GET: TipoProductos
        public async Task<IActionResult> Index()
        {
            return View(await _tipoProductoServices.ListaTipoProductos());
        }

        // GET: TipoProductos/Details/5
        public async Task<IActionResult> DetallesTipoP(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProducto = await _tipoProductoServices.TipoProductoId(id.Value);
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
                await _tipoProductoServices.GuardarTipoProducto(tipoProducto);
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

            var tipoProducto = await _tipoProductoServices.TipoProductoId(id.Value);
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
                await _tipoProductoServices.EditarTipoProducto(tipoProducto);                
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

            var tipoProducto = await _tipoProductoServices.TipoProductoId(id.Value);
            
            if (tipoProducto == null)
            {
                return NotFound();
            }

            await _tipoProductoServices.EliminarTipoProducto(tipoProducto);
            return RedirectToAction(nameof(Index));
        }
        /*
        private bool TipoProductoExists(int id)
        {
            return _context.TipoProductos.Any(e => e.TipoProductoId == id);
        }
        */
    }
}
