using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EstrelaNegra.API.DTO
{
    public class HealthDTO
    {
        public int Id { get; set; }
        public int? HorseId { get; set; }
        public DateTime? VermIve { get; set; }       
        public DateTime? VermFeb { get; set; }       
        public DateTime? Doramectina { get; set; }    
        public DateTime? Pouron { get; set; }       
        public DateTime? Triequi { get; set; }        
        public DateTime? Lex8 { get; set; }       
        public DateTime? Encefalogen { get; set; }      
        public DateTime? Garrotilho { get; set; }        
        public DateTime? Raiva { get; set; }        
        public DateTime? Herpes { get; set; }        
        public DateTime? Lepto { get; set; }
    }
}
