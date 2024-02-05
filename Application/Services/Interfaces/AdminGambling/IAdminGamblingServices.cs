using GamblingBackDW.Utilities;
using GamblingBackDW.Domain.Entities;
using GamblingBackDW.DTOs;

namespace GamblingBackDW.Application.Services.Interfaces.AdminGambling
{
    public interface IAdminGamblingServices
    {
        ///<summary>
        ///Traer Paises
        ///</summary>
        ResultResponse<List<Teams>> GetTeams();
        ///<summary>
        ///Traer Partidos
        ///</summary>
        ResultResponse<List<GetMatchesDTO>> GetMatches();
        ///<summary>
        ///Insertar Partidos al sistema
        ///</summary>
        ResultResponse<string> InsertMatches(MatchesDTO matches);
        ///<summary>
        ///Actualizar Partidos al sistema
        ///</summary>
        ResultResponse<string> UpdateMatches(UpdateMatchesDTO matches);

        ///<summary>
        ///Desactivar partido
        ///</summary>
        ResultResponse<string> DisabledMatchById(DisabledMathcDTO idMatches);

    }
}
