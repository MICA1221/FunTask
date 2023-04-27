using FunTask.Models;
using Microsoft.EntityFrameworkCore;

namespace FunTask.Datos
{
    public class FunTaskerContext : DbContext
    {
        public FunTaskerContext(DbContextOptions<FunTaskerContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Hijo> Hijos { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Recompensa> Recompensas { get; set; }
    }
}

