using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamblingBackDW.Domain.Entities
{
    public class Matches
    {
        [Key]
        public Guid ID { get; set; }
        
        [ForeignKey("TeamA")]
        public Guid IdTeamA { get; set; }

        [ForeignKey("TeamB")]
        public Guid IdTeamB { get; set; }
        public int ScoreTeamA { get; set; }
        public int ScoreTeamB { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime DateRegistration { get; set; }
        public bool Enabled { get; set; }

        // Relaciones
        public virtual Teams TeamA { get; set; }
        public virtual Teams TeamB { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
