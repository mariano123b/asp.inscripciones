using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inscripciones.Models
{
    public class inscripciones
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public int alumnosid { get; set; }
        public Alumno? alumnos { get; set; }
        public int carreraid { get; set; } 
        public Carrera? carrera  { get; set; }
        [NotMapped]
        public string? Inscripto 
        {
            get { return alumnos?.ApellidoNombre?? string.Empty; }
        }
    }
}
