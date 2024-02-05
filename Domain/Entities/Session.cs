using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamblingBackDW.Domain.Entities
{
    public class Session
    {
        [Key]
        public Guid ID { get; set; }
        public string SessionName { get; set; }

        [ForeignKey("Matches")]
        public Guid IdMatches { get; set; }
        public string SessionCode { get; set; }
        public bool Enabled { get; set; }

        // Relaciones
        public virtual Matches Matches { get; set; }
    }
}
