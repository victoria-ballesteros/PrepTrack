using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace RegistroPreparadurias.Models.Preparadores
{
    [Table("Preparadores")]
    public class Preparadores : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("nombre")]
        public string? Nombre { get; set; }

        [Column("nombre_materia")]
        public string? NombreMateria { get; set; }

        [Column("dia")]
        public int Dia { get; set; }

        [Column("turno")]
        public int Turno { get; set; }
    }
}