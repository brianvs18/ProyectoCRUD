using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCRUD.Models.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        
        [DisplayName("Tipo de Producto")]
        [Required(ErrorMessage = "El tipo de producto es obligatorio")]
        public int TipoProductoId { get; set; }
        public virtual TipoProducto TipoProducto { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        public int Precio { get; set; }
    }
}
