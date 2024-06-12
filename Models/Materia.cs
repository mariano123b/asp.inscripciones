using System.ComponentModel.DataAnnotations;

namespace Inscripciones.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        [Display(Name = "Año Carrera")]
        public int aniocarreraId { get; set; }
        public AnioCarrera? aniocarrera { get; set; }
        public override string ToString()
        {
            return nombre;
        }

    }
}
