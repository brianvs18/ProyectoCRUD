using ProyectoCRUD.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCRUD.Models.Abstract
{
    public interface IProductoBusiness
    {
        Task<IEnumerable<Producto>> ObtenerProductos();
        Task<Producto> ObtenerProductoPorId(int id);
        IEnumerable<TipoProducto> ObtenerListaTipoProductos();
        Task GuardarProducto(Producto producto);
    }
}
