using System.ComponentModel.DataAnnotations.Schema;

namespace GamblingBackDW.DTOs
{
    public class GamblingsDTO
    {
        public Guid IdSessionDTO { get; set; }
        public Guid IdSessionPersonDTO { get; set; }
        public int ScoreTeamADTO { get; set; }
        public int ScoreTeamBDTO { get; set; }
    }
}
