using Microsoft.EntityFrameworkCore;
using ProyectoCRUD.Models.Abstract;
using ProyectoCRUD.Models.DAL;
using ProyectoCRUD.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCRUD.Models.Business
{
    public class ProductoBusiness : IProductoBusiness
    {
        private readonly DbContextProyecto _context;

        public ProductoBusiness(DbContextProyecto context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            return(await _context.Productos.Include("TipoProducto").ToListAsync());
        }


        public async Task<Producto> ObtenerProductoPorId(int id)
        {
            return (await _context.Productos.FirstOrDefaultAsync(m => m.ProductoId == id));
        }

        public IEnumerable<TipoProducto> ObtenerListaTipoProductos()
        {
            return _context.TipoProductos.ToList();
        }

        public async Task GuardarProducto(Producto producto)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task EditarProducto(Producto producto)
        {
            _context.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task ELiminarpProducto(Producto producto)
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
    }
}
