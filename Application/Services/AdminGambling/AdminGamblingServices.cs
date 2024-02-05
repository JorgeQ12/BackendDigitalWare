using GamblingBackDW.Resources;
using GamblingBackDW.Utilities;
using GamblingBackDW.Validators;
using GamblingBackDW.Application.Services.Interfaces.AdminGambling;
using GamblingBackDW.Domain.Entities;
using GamblingBackDW.DTOs;
using AutoMapper;
using GamblingBackDW.SocketSignalR;
using GamblingBackDW.Domain.Services.Interfaces.AdminGambling;

namespace GamblingBackDW.Application.Services.AdminGambling
{
    public class AdminGamblingServices : IAdminGamblingServices
    {
        private readonly IMapper _mapper;
        private readonly SocketMessage _SocketMessage;
        private readonly IAdminGamblingDomain _AdminGamblingDomain;
        private readonly GlobalValidator _globalValidator;

        public AdminGamblingServices(IAdminGamblingDomain adminGamblingDomain, GlobalValidator globalValidator, IMapper mapper, SocketMessage socketMessage)
        {
            _AdminGamblingDomain = adminGamblingDomain;
            _mapper = mapper;
            _globalValidator = globalValidator;
            _SocketMessage = socketMessage;
        }

        ///<summary>
        ///Traer Paises
        ///</summary>
        public ResultResponse<List<Teams>> GetTeams()
        {
            try
            {
                List<Teams> teams = _AdminGamblingDomain.GetTeams();

                if(teams != null)
                {
                    return new ResultResponse<List<Teams>> (true, teams);
                }

                return new ResultResponse<List<Teams>>(false, GlobalResponses.NoFoundTeams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Traer Partidos
        ///</summary>
        public ResultResponse<List<GetMatchesDTO>> GetMatches()
        {
            try
            {
                List<GetMatchesDTO> matches = _AdminGamblingDomain.GetMatches();

                if (matches != null)
                {
                    return new ResultResponse<List<GetMatchesDTO>>(true, matches);
                }

                return new ResultResponse<List<GetMatchesDTO>>(false, GlobalResponses.NoFoundMatch);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Insertar Partidos al sistema
        ///</summary>
        public ResultResponse<string> InsertMatches(MatchesDTO matches)
        {
            try
            {
                var validationErrors = _globalValidator.ValidateMatches(matches);
                if (validationErrors != null)
                {
                    return validationErrors;
                }

                _AdminGamblingDomain.InsertMatches(_mapper.Map<MatchesDTO, Matches>(matches));

                return new ResultResponse<string>(true, GlobalResponses.InsertMatches);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Actualizar Partidos al sistema
        ///</summary>
        public ResultResponse<string> UpdateMatches(UpdateMatchesDTO matches)
        {
            try
            {
                var validationErrors = _globalValidator.ValidateUpdateMatches(matches);
                if (validationErrors != null)
                {
                    return validationErrors;
                }

                Matches matchesExist = _AdminGamblingDomain.GetMatchById(matches.IdMatchDTO);
                if(matchesExist != null)
                {
                    _AdminGamblingDomain.UpdateMatches(_mapper.Map(matches, matchesExist));
                    _SocketMessage.SendMessage("AdminMatch", "Se Actuliza Partido", matches.IdMatchDTO.ToString());

                    return new ResultResponse<string>(true, GlobalResponses.UpdateMatches);
                }

                return new ResultResponse<string>(false, GlobalResponses.NoFoundMatches);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Desactivar partido
        ///</summary>
        public ResultResponse<string> DisabledMatchById(DisabledMathcDTO idMatches)
        {
            try
            {
                Matches matchesExist = _AdminGamblingDomain.GetMatchById(idMatches.IdMatchesDTO);

                if (matchesExist != null)
                {
                    matchesExist.Enabled = false;
                    var SessionCode = _AdminGamblingDomain.DisabledMatchById(matchesExist);
                    _SocketMessage.SendMessage("AdminMatch", "Se Actuliza Partido", idMatches.IdMatchesDTO.ToString());
                    return new ResultResponse<string>(true, GlobalResponses.UpdateMatches);
                }

                return new ResultResponse<string>(false, GlobalResponses.NoFoundMatches);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
