namespace GamblingBackDW.DTOs
{
    public class GetMatchByCodeDTO
    {
        public Guid IdMatchDTO { get; set; }
        public string TeamADTO { get; set; }
        public string TeamBDTO { get; set; }
        public int ScoreTeamADTO { get; set; }
        public int ScoreTeamBDTO { get; set; }
        public DateTime DateTimeMatchDTO { get; set; }
        public bool EnabledDTO { get; set; }
    }
}
