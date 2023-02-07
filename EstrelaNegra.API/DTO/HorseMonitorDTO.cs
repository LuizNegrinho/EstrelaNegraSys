using EstrelaNegra.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstrelaNegra.API.DTO
{
    public class HorseMonitorDTO
    {
        public HorseMonitorDTO()
        {
            EquineGrowth = new HashSet<EquineGrowth>();
            EquineHlthFlwup = new HashSet<EquineHlthFlwup>();
        }

        [Key]
        [Required]

        public int HorseId { get; set; }

        [StringLength(512)]
        public string HorseName { get; set; }

        [StringLength(512)]
        public string Sufixx { get; set; }

        public int? ScoreGen { get; set; }

        [StringLength(1)]
        public string Sex { get; set; }

        public DateTime? Birth { get; set; }

        public bool? Live { get; set; }

        public bool? Own { get; set; }

        [StringLength(512)]
        public string CoatColor { get; set; }

        [StringLength(512)]
        public string Breeder { get; set; }

        [StringLength(512)]
        public string ActlOwner { get; set; }

        public int? FatherId { get; set; }

        public int? MotherId { get; set; }

        public virtual ICollection<EquineGrowth> EquineGrowth { get; set; }

        public virtual ICollection<EquineHlthFlwup> EquineHlthFlwup { get; set; }
    }
}
