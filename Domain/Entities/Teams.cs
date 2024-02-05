using System.ComponentModel.DataAnnotations;

namespace GamblingBackDW.Domain.Entities
{
    public class Teams
    {
        [Key]
        public Guid ID { get; set; }
        public string CountryName { get; set; }
        public bool Enabled { get; set; }

    }
}
