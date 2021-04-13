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
    public class TipoProductoServices: ITipoProductoServices
    {
        private readonly DbContextProyecto _context;

        public TipoProductoServices(DbContextProyecto context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoProducto>> ListaTipoProductos()
        {
            return (await _context.TipoProductos.ToListAsync());
        }

        public async Task<TipoProducto> TipoProductoId(int id)
        {
            return (await _context.TipoProductos.FirstOrDefaultAsync(m => m.TipoProductoId == id));
        }

        public async Task GuardarTipoProducto(TipoProducto tipoProducto)
        {
            _context.Add(tipoProducto);
            await _context.SaveChangesAsync();
        }

        public async Task EditarTipoProducto(TipoProducto tipoProducto)
        {
            _context.Update(tipoProducto);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarTipoProducto(TipoProducto tipoProducto)
        {
            _context.TipoProductos.Remove(tipoProducto);
            await _context.SaveChangesAsync();
        }
    }
}
