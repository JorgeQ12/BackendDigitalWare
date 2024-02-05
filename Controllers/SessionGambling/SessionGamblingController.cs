using GamblingBackDW.Application.Services.Interfaces.SessionGambling;
using GamblingBackDW.Domain.Entities;
using GamblingBackDW.DTOs;
using GamblingBackDW.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace GamblingBackDW.Controllers.SessionGambling
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionGamblingController : Controller
    {
        private readonly ISessionGamblingServices _SessionGamblingServices;
        public SessionGamblingController(ISessionGamblingServices sessionGamblingServices)
        {
            _SessionGamblingServices = sessionGamblingServices;
        }

        ///<summary>
        ///Traer Usuarios de la session
        ///</summary>
        [HttpPost]
        [Route(nameof(SessionGamblingController.GetUserByMatch))]
        public ResultResponse<List<GetUsersSessionDTO>> GetUserByMatch(CodeDTO code) => _SessionGamblingServices.GetUserByMatch(code);

        ///<summary>
        ///Traer Partido y actualizaciones
        ///</summary>
        [HttpPost]
        [Route(nameof(SessionGamblingController.GetMatchByCode))]
        public ResultResponse<GetMatchByCodeDTO> GetMatchByCode(CodeDTO code) => _SessionGamblingServices.GetMatchByCode(code);

        ///<summary>
        ///Insertar Sessiones de partidos
        ///</summary>
        [HttpPost]
        [Route(nameof(SessionGamblingController.InsertSessionMatches))]
        public ResultResponse<string> InsertSessionMatches(SessionDTO session) => _SessionGamblingServices.InsertSessionMatches(session);

        ///<summary>
        ///Insertar Personas a sessiones de partidos
        ///</summary>
        [HttpPost]
        [Route(nameof(SessionGamblingController.InsertSessionPerson))]
        public ResultResponse<string> InsertSessionPerson(SessionPersonDTO sessionPerson) => _SessionGamblingServices.InsertSessionPerson(sessionPerson);

        ///<summary>
        ///Actualizar la apuesta de usuario
        ///</summary>
        [HttpPut]
        [Route(nameof(SessionGamblingController.UpdateGamblingByPerson))]
        public ResultResponse<string> UpdateGamblingByPerson(UpdateSessionPersonDTO sessionPerson) => _SessionGamblingServices.UpdateGamblingByPerson(sessionPerson);


    }
}
