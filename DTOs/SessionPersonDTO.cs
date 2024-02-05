using System.Text.Json.Serialization;


namespace GamblingBackDW.DTOs
{
    public class SessionPersonDTO
    {
        [JsonIgnore]
        public Guid IdSessionDTO { get; set; }
        public string PersonNameDTO { get; set; }
        public string PersonIdentificationDTO { get; set; }
        public string SessionCode { get; set; }
        public int ScoreTeamADTO { get; set; }
        public int ScoreTeamBDTO { get; set; }
    }
}
