using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GamblingBackDW.DTOs
{
    public class SessionDTO
    {
        public string SessionNameDTO { get; set; }
        public Guid IdMatchesDTO { get; set; }
    }
}
