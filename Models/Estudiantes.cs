using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace RegistroPreparadurias.Models
{
    [Table("Estudiantes")]
    public class Estudiantes : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("cedula")]
        public string? Cedula { get; set; }
    }
}