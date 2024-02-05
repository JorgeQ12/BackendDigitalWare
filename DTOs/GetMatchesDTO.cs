using System.ComponentModel.DataAnnotations.Schema;

namespace GamblingBackDW.DTOs
{
    public class GetMatchesDTO
    {
        public Guid IdDTO { get; set; }
        public Guid IdTeamADTO { get; set; }
        public string NameTemaADTO { get; set; }
        public Guid IdTeamBDTO { get; set; }
        public string NameTemaBDTO { get; set; }
        public int ScoreTeamA { get; set; }
        public int ScoreTeamB { get; set; }
        public DateTime DateTime { get; set; }
        public bool Enabled { get; set; }
    }
}
