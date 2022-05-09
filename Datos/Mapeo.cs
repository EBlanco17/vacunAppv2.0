using System.Data.Entity;
using Utilitarios;

namespace Datos
{
    class Mapeo : DbContext
    {
        static Mapeo()
        {
            Database.SetInitializer<Mapeo>(null);
        }
        private readonly string schema;

        public Mapeo() : base("name=MiConexion")
        { }

        public DbSet<EPersona> persona { get; set; }
        public DbSet<EFormulario> formulario { get; set; }
        public DbSet<EFarmaceutica> farmaceutica { get; set; }
        public DbSet<EVacuna> vaccine { get; set; }
        public DbSet<EVacunasAplicadas> vacunaAplicada { get; set; }
        public DbSet<ESolicitudAdministrador> solicitudAdmin { get; set; }
        public DbSet<ESolicitud> solicitud { get; set; }
        public DbSet<ELocalidad> localidad { get; set; }
        public DbSet<EBarrio> barrio { get; set; }
    }
}
