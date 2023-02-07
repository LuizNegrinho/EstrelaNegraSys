using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EstrelaNegra.API.DTO
{
    [Table("EQUINE_GROWTH")]
    public class HealthDTO
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("HORSE_ID")]
        public int? HorseId { get; set; }
        [Column("VERM_IVE", TypeName = "datetime")]
        public DateTime? VermIve { get; set; }
        [Column("VERM_FEB", TypeName = "datetime")]
        public DateTime? VermFeb { get; set; }
        [Column("DORAMECTINA", TypeName = "datetime")]
        public DateTime? Doramectina { get; set; }
        [Column("POURON", TypeName = "datetime")]
        public DateTime? Pouron { get; set; }
        [Column("TRIEQUI", TypeName = "datetime")]
        public DateTime? Triequi { get; set; }
        [Column("LEX8", TypeName = "datetime")]
        public DateTime? Lex8 { get; set; }
        [Column("ENCEFALOGEN", TypeName = "datetime")]
        public DateTime? Encefalogen { get; set; }
        [Column("GARROTILHO", TypeName = "datetime")]
        public DateTime? Garrotilho { get; set; }
        [Column("RAIVA", TypeName = "datetime")]
        public DateTime? Raiva { get; set; }
        [Column("HERPES", TypeName = "datetime")]
        public DateTime? Herpes { get; set; }
        [Column("LEPTO", TypeName = "datetime")]
        public DateTime? Lepto { get; set; }
    }
}
