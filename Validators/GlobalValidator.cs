using GamblingBackDW.Resources;
using GamblingBackDW.Utilities;
using GamblingBackDW.DTOs;
using GamblingBackDW.Domain.Entities;

namespace GamblingBackDW.Validators
{
    public class GlobalValidator
    {
        public ResultResponse<string> ValidateMatches(MatchesDTO matches)
        {

            if (matches.IdTeamADTO.Equals(Guid.Empty) || matches.IdTeamBDTO.Equals(Guid.Empty))
            {
                return new ResultResponse<string>(false, GlobalResponses.IdNoGuidNull);
            }
            if (matches.DateTimeDTO == DateTime.MinValue)
            {
                return new ResultResponse<string>(false, GlobalResponses.DateTimeIncorrect);
            }
            return null;
        }

        public ResultResponse<string> ValidateUpdateMatches(UpdateMatchesDTO matches)
        {

            if (matches.IdMatchDTO.Equals(Guid.Empty))
            {
                return new ResultResponse<string>(false, GlobalResponses.IdMatchNull);
            }
            if (matches.ScoreTeamBDTO < 0 || matches.ScoreTeamBDTO < 0)
            {
                return new ResultResponse<string>(false, GlobalResponses.ScoreNotNull);
            }
            return null;
        }

        public ResultResponse<string> ValidateInsertSessionMatches(SessionDTO session)
        {

            if (string.IsNullOrWhiteSpace(session.SessionNameDTO))
            {
                return new ResultResponse<string>(false, GlobalResponses.SessionNameNull);
            }
            if (session.IdMatchesDTO.Equals(Guid.Empty))
            {
                return new ResultResponse<string>(false, GlobalResponses.IdMatchNull);
            }

            return null;
        }

        public ResultResponse<string> ValidateInsertSessionPerson(SessionPersonDTO sessionPerson)
        {

            if ((string.IsNullOrWhiteSpace(sessionPerson.SessionCode)))
            {
                return new ResultResponse<string>(false, GlobalResponses.SessionCodeNull);
            }
            if (string.IsNullOrWhiteSpace(sessionPerson.PersonNameDTO))
            {
                return new ResultResponse<string>(false, GlobalResponses.PersonNameNull);
            }
            if (string.IsNullOrWhiteSpace(sessionPerson.PersonIdentificationDTO))
            {
                return new ResultResponse<string>(false, GlobalResponses.IdentificationNull);
            }
            if (sessionPerson.ScoreTeamBDTO < 0 || sessionPerson.ScoreTeamBDTO < 0)
            {
                return new ResultResponse<string>(false, GlobalResponses.ScoreNotNull);
            }
            return null;
        }

    }
}
