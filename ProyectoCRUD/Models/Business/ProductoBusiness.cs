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

        /*public async Task<IEnumerable<Producto>> ObtenerListaProductos()
        {
            return (SelectList(_context.TipoProductos.ToList(), "TipoProductoId", "Nombre"));
        }*/


        

    }
}
