using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamblingBackDW.Domain.Entities
{
    public class SessionPerson
    {
        [Key]
        public Guid ID { get; set; }
        public string PersonName { get; set; }
        public string PersonIdentification { get; set; }

        [ForeignKey("Session")]
        public Guid IdSession { get; set; }

        // Relaciones
        public virtual Session Session { get; set; }
    }
}
