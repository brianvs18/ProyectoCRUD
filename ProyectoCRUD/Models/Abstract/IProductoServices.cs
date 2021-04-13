using ProyectoCRUD.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCRUD.Models.Abstract
{
    public interface IProductoServices
    {
        Task<IEnumerable<Producto>> ListaProductos();
        Task<Producto> ObtenerProductoxId(int id);
        Task CrearProducto(Producto producto);
        Task EditarProducto(Producto producto);
        Task EliminarProducto(Producto producto);
        IEnumerable<TipoProducto> ObtenerListaTipoProductos();
    }
}
