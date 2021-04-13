using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoCRUD.Models.DAL;
using ProyectoCRUD.Models.Entities;
using ProyectoCRUD.ViewModels;

namespace ProyectoCRUD.Controllers
{
    public class ProductosController : Controller
    {
        //Conexion a la BD
        private readonly DbContextProyecto _context;

        //Inyeccion de la Clase DbContextProyecto
        public ProductosController(DbContextProyecto context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {           
            
            var productos = await _context.Productos.Include("TipoProducto").ToListAsync();

                return View(productos);
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Crear()
        {
            ViewData["listaTipoProductos"] = new SelectList(_context.TipoProductos.ToList(), "TipoProductoId", "Nombre");
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("ProductoId,Nombre,TipoProductoId,Cantidad,Precio")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            if (producto.TipoProductoId == 0)
            {
                ViewData["errorTipo"] = "Seleccione una opción";
            }            

            ViewData["listaTipoProductos"] = new SelectList(_context.TipoProductos.ToList(), "TipoProductoId", "Nombre");
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modificar(int id, [Bind("ProductoId,Nombre,TipoProductoId,Cantidad,Precio")] Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return NotFound();
            }

            var productoTemp = await _context.Productos.AsNoTracking().FirstOrDefaultAsync(prod => prod.ProductoId == producto.ProductoId);


            if (productoTemp == null || (productoTemp.ProductoId == producto.ProductoId))
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(producto);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductoExists(producto.ProductoId))
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
            }            
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }
            
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.ProductoId == id);
        }        
    }
}
