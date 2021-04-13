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
using ProyectoCRUD.ViewModels;

namespace ProyectoCRUD.Controllers
{
    public class ProductosController : Controller
    {
        //Conexion a la BD
        private readonly IProductoServices _productoServices;

        //Inyeccion de la Clase DbContextProyecto
        public ProductosController(IProductoServices productoServices)
        {
            _productoServices = productoServices;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {

            var productos = await _productoServices.ListaProductos();

                return View(productos);
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _productoServices.ObtenerProductoxId(id.Value);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Crear()
        {
            ViewData["listaTipoProductos"] = new SelectList(_productoServices.ObtenerListaTipoProductos(), "TipoProductoId", "Nombre");
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("ProductoId,Nombre,TipoProductoId,Cantidad,Precio")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                await _productoServices.CrearProducto(producto);
                return RedirectToAction(nameof(Index));
            }

            if (producto.TipoProductoId == 0)
            {
                ViewData["errorTipo"] = "Seleccione una opción";
            }

            ViewData["listaTipoProductos"] = new SelectList(_productoServices.ObtenerListaTipoProductos(), "TipoProductoId", "Nombre");
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _productoServices.ObtenerProductoxId(id.Value);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["listaTipoProductos"] = new SelectList(_productoServices.ObtenerListaTipoProductos(), "TipoProductoId", "Nombre");
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

            //var productoTemp = await _context.Productos.AsNoTracking().FirstOrDefaultAsync(prod => prod.ProductoId == producto.ProductoId);
            var productoTemp = await _productoServices.ObtenerProductoxId(producto.ProductoId);

            if (productoTemp == null || (productoTemp.ProductoId == producto.ProductoId))
            {
                if (ModelState.IsValid)
                {
                    await _productoServices.EditarProducto(producto);
                    
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["listaTipoProductos"] = new SelectList(_productoServices.ObtenerListaTipoProductos(), "TipoProductoId", "Nombre");
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _productoServices.ObtenerProductoxId(id.Value);
            if (producto == null)
            {
                return NotFound();
            }

            await _productoServices.EliminarProducto(producto);

            return RedirectToAction(nameof(Index));
        }

        /*
        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.ProductoId == id);
        }
        */
    }
}
