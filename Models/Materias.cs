using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace RegistroPreparadurias.Models
{
    [Table("Materias")]
    public class Materias : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("nombre")]
        public string? Nombre { get; set; }
    }
}