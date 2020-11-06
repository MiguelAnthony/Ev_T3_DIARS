using Ev_T3_DIARS.Models.Map;
using Ev_T3_DIARS.Models.Maps;
using Microsoft.EntityFrameworkCore;

namespace Ev_T3_DIARS.Models
{
    public class T3Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ejercicios> Ejercicios { get; set; }
        public DbSet<Rutina_Usuario> RutinaUsuarios { get; set; }
        public DbSet<Detalle_Rutina> DetalleRutinas { get; set; }


        public T3Context(DbContextOptions<T3Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new EjerciciosMap());
            modelBuilder.ApplyConfiguration(new Rutina_UsuarioMap());
            modelBuilder.ApplyConfiguration(new Detalle_RutinaMap());

        }
    }
}
