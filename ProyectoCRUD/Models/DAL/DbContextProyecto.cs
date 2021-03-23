using Microsoft.EntityFrameworkCore;
using ProyectoCRUD.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCRUD.Models.DAL
{
    public class DbContextProyecto: DbContext
    {
        public DbContextProyecto(DbContextOptions<DbContextProyecto> options): base(options)
        {

        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<TipoProducto> TipoProductos { get; set; }
    }
}
