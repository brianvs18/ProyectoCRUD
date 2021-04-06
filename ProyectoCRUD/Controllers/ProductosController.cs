using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoCRUD.Models.Abstract;
using ProyectoCRUD.Models.Business;
using ProyectoCRUD.Models.DAL;
using ProyectoCRUD.Models.Entities;
using ProyectoCRUD.ViewModels;

namespace ProyectoCRUD.Controllers
{
    public class ProductosController : Controller
    {
        

        //Conexion a la BD
        private readonly IProductoBusiness _productoBusiness;

        //Inyeccion de la Clase DbContextProyecto
        public ProductosController(IProductoBusiness productoBusiness)
        {
            _productoBusiness = productoBusiness;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            return View(await _productoBusiness.ObtenerProductos());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _productoBusiness.ObtenerProductoPorId(id.Value);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }
        
        // GET: Productos/Create
        public IActionResult Crear()
        {
            ViewData["TipoProducto"] = new SelectList( _productoBusiness.ObtenerListaTipoProductos(), "TipoProductoId", "Nombre");

            return View();
        }
        
        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("ProductoId,Nombre,TipoProductoId,Cantidad,Precio")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                var productoTemp = await _productoBusiness.ObtenerProductoPorId(producto.ProductoId);
                if (productoTemp == null)
                {
                    await _productoBusiness.GuardarProducto(producto);
                    return RedirectToAction(nameof(Index));
                }
            }

            if (producto.TipoProductoId == 0)
            {
                ViewData["errorProducto"] = "seleccione un tipo de producto";
            }

            ViewData["listaProducto"] = new SelectList(_productoBusiness.ObtenerListaTipoProductos(), "TipoProductoId", "Nombre"); 

            return View(producto);
        }
        
        
        // GET: Productos/Edit/5
        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _productoBusiness.ObtenerProductoPorId(id.Value);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }
        
        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modificar(int id, [Bind("ProductoId,Nombre,TipoProductoId,Cantidad,Precio")] Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _productoBusiness.EditarProducto(producto);
                return RedirectToAction(nameof(Index));
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
            var producto = await _productoBusiness.ObtenerProductoPorId(id.Value);

            await _productoBusiness.ELiminarpProducto(producto);
            
            if (producto == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
        /*
        // POST: Productos/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirmar(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.ProductoId == id);
        }*/
    }
}
