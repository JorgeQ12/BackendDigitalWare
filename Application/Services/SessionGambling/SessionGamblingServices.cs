using AutoMapper;
using GamblingBackDW.Application.Services.Interfaces.SessionGambling;
using GamblingBackDW.Controllers.SessionGambling;
using GamblingBackDW.Domain.Entities;
using GamblingBackDW.Domain.Services.Interfaces.AdminGambling;
using GamblingBackDW.Domain.Services.Interfaces.SessionGambling;
using GamblingBackDW.Domain.Services.SessionGambling;
using GamblingBackDW.DTOs;
using GamblingBackDW.Resources;
using GamblingBackDW.SocketSignalR;
using GamblingBackDW.Utilities;
using GamblingBackDW.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GamblingBackDW.Application.Services.SessionGambling
{
    public class SessionGamblingServices : ISessionGamblingServices
    {

        private readonly IMapper _mapper;
        private readonly SocketMessage _SocketMessage;
        private readonly IAdminGamblingDomain _AdminGamblingDomain;
        private readonly ISessionGamblingDomain _SessionGamblingDomain;
        private readonly GlobalValidator _globalValidator;

        public SessionGamblingServices(ISessionGamblingDomain sessionGamblingDomain, GlobalValidator globalValidator, IMapper mapper, SocketMessage socketMessage, IAdminGamblingDomain adminGamblingDomain)
        {
            _SessionGamblingDomain = sessionGamblingDomain;
            _mapper = mapper;
            _globalValidator = globalValidator;
            _SocketMessage = socketMessage;
            _AdminGamblingDomain = adminGamblingDomain;
        }

        ///<summary>
        ///Traer Usuarios de la session
        ///</summary>
        public ResultResponse<List<GetUsersSessionDTO>> GetUserByMatch(CodeDTO code)
        {
            try
            {
                List<GetUsersSessionDTO> getUsersSession = _SessionGamblingDomain.GetUserByMatch(code.CodeMatchDTO);

                if (getUsersSession != null)
                {
                    return new ResultResponse<List<GetUsersSessionDTO>>(false, getUsersSession);
                }
                return new ResultResponse<List<GetUsersSessionDTO>>(false, GlobalResponses.NoUserMatches);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Traer Partido y actualizaciones
        ///</summary>
        public ResultResponse<GetMatchByCodeDTO> GetMatchByCode(CodeDTO code)
        {
            try
            {
                GetMatchByCodeDTO getMatchesSession = _SessionGamblingDomain.GetMatchByCode(code.CodeMatchDTO);

                if (getMatchesSession != null)
                {
                    return new ResultResponse<GetMatchByCodeDTO>(true, getMatchesSession);
                }
                return new ResultResponse<GetMatchByCodeDTO>(false, GlobalResponses.NoUserMatches);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        ///<summary>
        ///Insertar Sessiones de partidos
        ///</summary>
        public ResultResponse<string> InsertSessionMatches(SessionDTO session)
        {
            try
            {
                var validationErrors = _globalValidator.ValidateInsertSessionMatches(session);
                if (validationErrors != null)
                {
                    return validationErrors;
                }

                Matches matchesExist = _AdminGamblingDomain.GetMatchById(session.IdMatchesDTO);
                if (matchesExist != null)
                {
                    var SessionCode = _SessionGamblingDomain.InsertSessionMatches(_mapper.Map<SessionDTO, Session>(session));
                    return new ResultResponse<string>(true, SessionCode);
                }

                return new ResultResponse<string>(false, GlobalResponses.NoFoundMatches);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Insertar Personas a sessiones de partidos
        ///</summary>
        public ResultResponse<string> InsertSessionPerson(SessionPersonDTO sessionPerson)
        {
            try
            {
                var validationErrors = _globalValidator.ValidateInsertSessionPerson(sessionPerson);
                if (validationErrors != null)
                {
                    return validationErrors;
                }

                Guid? idSessionExist = _SessionGamblingDomain.GetSessionByCode(sessionPerson.SessionCode);
                if (idSessionExist != null)
                {
                    sessionPerson.IdSessionDTO = (Guid)idSessionExist;
                    Guid idSessionPerson = _SessionGamblingDomain.InsertSessionPerson(_mapper.Map<SessionPersonDTO, SessionPerson>(sessionPerson));

                    GamblingsDTO gamblingsRegister = new GamblingsDTO
                    {
                        IdSessionDTO = sessionPerson.IdSessionDTO,
                        IdSessionPersonDTO = idSessionPerson,
                        ScoreTeamADTO = sessionPerson.ScoreTeamADTO,
                        ScoreTeamBDTO = sessionPerson.ScoreTeamBDTO
                    };

                    _SessionGamblingDomain.InsertGamblings(_mapper.Map<GamblingsDTO, Gamblings>(gamblingsRegister));

                    _SocketMessage.SendMessage("UserNew", "Se Ingresa Usuario", sessionPerson.IdSessionDTO.ToString());

                    return new ResultResponse<string>(true, GlobalResponses.InsertGamblingMatches);
                }

                return new ResultResponse<string>(false, GlobalResponses.IdSessionNotFound);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Actualizar la apuesta de usuario
        ///</summary>
        public ResultResponse<string> UpdateGamblingByPerson(UpdateSessionPersonDTO sessionPerson)
        {
            try
            {
                Gamblings gamblingExist = _SessionGamblingDomain.GetGamblingByPerson(sessionPerson.IdSessionPersonDTO);
                if (gamblingExist != null)
                {
                    _SessionGamblingDomain.UpdateGamblingByPerson(_mapper.Map(sessionPerson, gamblingExist));
                    _SocketMessage.SendMessage("UserUpdate", "Se Actuliza Partido", gamblingExist.IdSession.ToString());

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
