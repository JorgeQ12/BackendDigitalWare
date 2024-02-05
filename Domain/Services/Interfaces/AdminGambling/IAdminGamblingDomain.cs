using GamblingBackDW.Utilities;
using GamblingBackDW.Domain.Entities;
using GamblingBackDW.DTOs;

namespace GamblingBackDW.Domain.Services.Interfaces.AdminGambling
{
    public interface IAdminGamblingDomain
    {
        ///<summary>
        ///Traer Paises
        ///</summary>
        List<Teams> GetTeams();
        ///<summary>
        ///Traer Partidos
        ///</summary>
        List<GetMatchesDTO> GetMatches();

        ///<summary>
        ///Insertar Partidos al sistema
        ///</summary>
        Matches InsertMatches(Matches matches);
        ///<summary>
        ///Actualizar Partidos al sistema
        ///</summary>
        Matches UpdateMatches(Matches matches);

        ///<summary>
        ///Validar si existe el Match
        ///</summary>
        Matches GetMatchById(Guid idMatch);
        ///<summary>
        ///Desactivar partido
        ///</summary>
        Matches DisabledMatchById(Matches idMatches);
    }
}
