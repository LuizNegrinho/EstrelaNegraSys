using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EstrelaNegra.API.DTO
{
    [Table("EQUINE_GROWTH")]
    public class GrowthDTO
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("HORSE_ID")]
        public int? HorseId { get; set; }
        [Column("ACTUAL")]
        public int? Actual { get; set; }
        public int? M0 { get; set; }
        public int? M1 { get; set; }
        public int? M2 { get; set; }
        public int? M3 { get; set; }
        public int? M4 { get; set; }
        public int? M5 { get; set; }
        public int? M6 { get; set; }
        public int? M7 { get; set; }
        public int? M8 { get; set; }
        public int? M9 { get; set; }
        public int? M10 { get; set; }
        public int? M11 { get; set; }
        public int? M12 { get; set; }
        public int? M13 { get; set; }
        public int? M14 { get; set; }
        public int? M15 { get; set; }
        public int? M16 { get; set; }
        public int? M17 { get; set; }
        public int? M18 { get; set; }
        public int? M19 { get; set; }
        public int? M20 { get; set; }
        public int? M21 { get; set; }
        public int? M22 { get; set; }
        public int? M23 { get; set; }
        public int? M24 { get; set; }
        public int? M25 { get; set; }
        public int? M26 { get; set; }
        public int? M27 { get; set; }
        public int? M28 { get; set; }
        public int? M29 { get; set; }
        public int? M30 { get; set; }
        public int? M31 { get; set; }
        public int? M32 { get; set; }
        public int? M33 { get; set; }
        public int? M34 { get; set; }
        public int? M35 { get; set; }
        public int? M36 { get; set; }
        public int? M48 { get; set; }
        public int? M60 { get; set; }
        [Column("PROJECTION")]
        public int? Projection { get; set; }

    }
}
