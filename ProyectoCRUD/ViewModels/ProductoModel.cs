using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCRUD.ViewModels
{
    public class ProductoModel
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string TipoProducto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
    }
}
