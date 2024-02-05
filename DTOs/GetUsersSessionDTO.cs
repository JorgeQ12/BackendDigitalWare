namespace GamblingBackDW.DTOs
{
    public class GetUsersSessionDTO
    {
        public Guid IdSessionDTO { get; set; }
        public Guid IdSessionPersonDTO { get; set; }
        public string PersonNameDTO { get; set; }
        public string PersonIdentificationDTO { get; set; }
        public int ScoreTeamADTO { get; set; }
        public int ScoreTeamBDTO { get; set; }
    }
}
