using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCRUD.Models.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string TipoProductoId { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
    }
}
