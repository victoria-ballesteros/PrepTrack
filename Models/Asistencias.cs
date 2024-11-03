using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace RegistroPreparadurias.Models
{
    [Table("Asistencias")]
    public class Asistencias : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("nombre_preparador")]
        public string? NombrePreparador { get; set; }

        [Column("cedula_estudiante")]
        public string? CedulaEstudiante { get; set; }

        [Column("nombre_materia")]
        public string? NombreMateria { get; set; }

        [Column("seccion")]
        public int Seccion { get; set; }
   }
}