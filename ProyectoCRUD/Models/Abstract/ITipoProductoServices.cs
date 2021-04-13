using ProyectoCRUD.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCRUD.Models.Abstract
{
    public interface ITipoProductoServices
    {
        Task<IEnumerable<TipoProducto>> ListaTipoProductos();
        Task<TipoProducto> TipoProductoId(int id);
        Task GuardarTipoProducto(TipoProducto tipoProducto);
        Task EditarTipoProducto(TipoProducto tipoProducto);
        Task EliminarTipoProducto(TipoProducto tipoProducto);
    }
}
