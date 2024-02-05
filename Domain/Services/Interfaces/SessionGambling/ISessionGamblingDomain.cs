using GamblingBackDW.Domain.Entities;
using GamblingBackDW.DTOs;
using GamblingBackDW.Utilities;

namespace GamblingBackDW.Domain.Services.Interfaces.SessionGambling
{
    public interface ISessionGamblingDomain
    {
        ///<summary>
        ///Traer Usuarios de la session
        ///</summary>
        List<GetUsersSessionDTO> GetUserByMatch(string code);

        ///<summary>
        ///Traer Partido y actualizaciones
        ///</summary>
        GetMatchByCodeDTO GetMatchByCode(string code);
        ///<summary>
        ///Insertar Sessiones de partidos
        ///</summary>
        string InsertSessionMatches(Session session);

        ///<summary>
        ///Traer ID de session activa
        ///</summary>
        Guid? GetSessionByCode(string code);

        ///<summary>
        ///Insertar Personas a sessiones de partidos
        ///</summary>
        Guid InsertSessionPerson(SessionPerson sessionPerson);

        ///<summary>
        ///Insertar Apuestas por persona
        ///</summary>
        Gamblings InsertGamblings(Gamblings gamblings);

        ///<summary>
        ///Traer la apuesta del usuario
        ///</summary>
        Gamblings GetGamblingByPerson(Guid sessionPerson);
        ///<summary>
        ///Actualizar la apuesta de usuario
        ///</summary>
        Gamblings UpdateGamblingByPerson(Gamblings sessionPerson);



    }
}
