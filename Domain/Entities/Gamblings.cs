using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamblingBackDW.Domain.Entities
{
    public class Gamblings
    {
        [Key]
        public Guid ID { get; set; }

        [ForeignKey("Session")]
        public Guid IdSession { get; set; }

        [ForeignKey("SessionPerson")]
        public Guid IdSessionPerson { get; set; }
        public int ScoreTeamA { get; set; }
        public int ScoreTeamB { get; set; }
        public bool Enabled { get; set; }

        // Relaciones
        public virtual Session Session { get; set; }
        public virtual SessionPerson SessionPerson { get; set; }
    }
}
