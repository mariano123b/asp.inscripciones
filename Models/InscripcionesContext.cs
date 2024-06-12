using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;


namespace Inscripciones.Models
{
    public class InscripcionesContext : DbContext
    {
        public InscripcionesContext(DbContextOptions<InscripcionesContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;      
            //               Database=InscripcionesContext;
            //               User Id = sa; Password = 123;
            //               MultipleActiveResultSets = True; 
            //               Encrypt=false ") ;
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string cadenaConexion = "Server=5.57.213.17;database=smartsof_marianobaroni;User=smartsof_baroni;Password=baronimariano123;";
            
            optionsBuilder.UseMySql(cadenaConexion,
            ServerVersion.AutoDetect(cadenaConexion));
        }

        public virtual DbSet<Alumno> alumnos { get; set; }
        public virtual DbSet<Carrera> carreras { get; set; }
        public virtual DbSet<inscripciones> Inscripciones { get; set; }
        public virtual DbSet<AnioCarrera> AnioCarreras { get; set; }
        public virtual DbSet<Materia> Materias { get; set; } 
    }
}
