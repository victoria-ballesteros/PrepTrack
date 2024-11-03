namespace RegistroPreparadurias.Models
{
    public class Registro
    {
        public required string Cedula { get; set; }

        public required string NombreMateria { get; set; }

        public Guid Preparador { get; set; }

        public int Seccion { get; set; }

    }
}