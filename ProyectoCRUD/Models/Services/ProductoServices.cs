using Microsoft.EntityFrameworkCore;
using ProyectoCRUD.Models.Abstract;
using ProyectoCRUD.Models.DAL;
using ProyectoCRUD.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCRUD.Models.Services
{
    public class ProductoServices: IProductoServices
    {
        private readonly DbContextProyecto _context;

        public ProductoServices(DbContextProyecto context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> ListaProductos()
        {
            return (await _context.Productos.Include("TipoProducto").ToListAsync());
        }

        public async Task<Producto> ObtenerProductoxId(int id)
        {            
            return (await _context.Productos.AsNoTracking().FirstOrDefaultAsync(m => m.ProductoId == id));
        }

        public async Task CrearProducto(Producto producto)
        {
            try
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }            
        }

        public async Task EditarProducto(Producto producto)
        {
            try
            {
                _context.Update(producto);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }            
        }

        public async Task EliminarProducto(Producto producto)
        {
            try
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IEnumerable<TipoProducto> ObtenerListaTipoProductos()
        {
            return (_context.TipoProductos.ToList());
        }
    }
}
