namespace Inscripciones.Models
{
    public class AnioCarrera
    {
        public int Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public int carreraid { get; set; }
        public Carrera? carrera { get; set; }
        public override string ToString()
        {
            return nombre;
        }
    }

}
