using GamblingBackDW.Controllers.SessionGambling;
using GamblingBackDW.DTOs;
using GamblingBackDW.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace GamblingBackDW.Application.Services.Interfaces.SessionGambling
{
    public interface ISessionGamblingServices
    {
        ///<summary>
        ///Traer Usuarios de la session
        ///</summary>
        ResultResponse<List<GetUsersSessionDTO>> GetUserByMatch(CodeDTO code);

        ///<summary>
        ///Traer Partido y actualizaciones
        ///</summary>
        ResultResponse<GetMatchByCodeDTO> GetMatchByCode(CodeDTO code);
        ///<summary>
        ///Insertar Sessiones de partidos
        ///</summary>
        ResultResponse<string> InsertSessionMatches(SessionDTO session);

        ///<summary>
        ///Insertar Personas a sessiones de partidos
        ///</summary>
        ResultResponse<string> InsertSessionPerson(SessionPersonDTO sessionPerson);
        ///<summary>
        ///Actualizar la apuesta de usuario
        ///</summary>
        ResultResponse<string> UpdateGamblingByPerson(UpdateSessionPersonDTO sessionPerson);

    }
}
