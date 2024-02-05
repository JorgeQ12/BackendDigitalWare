using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamblingBackDW.DTOs
{
    public class MatchesDTO
    {
        public Guid IdTeamADTO { get; set; }
        public Guid IdTeamBDTO { get; set; }
        public DateTime DateTimeDTO { get; set; }
    }
}
