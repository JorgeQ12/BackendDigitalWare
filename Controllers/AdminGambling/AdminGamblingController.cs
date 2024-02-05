using GamblingBackDW.Utilities;
using GamblingBackDW.Application.Services.Interfaces.AdminGambling;
using GamblingBackDW.Domain.Entities;
using GamblingBackDW.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamblingBackDW.Controllers.SessionGambling;

namespace GamblingBackDW.controller.AdminGambling
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminGamblingController : Controller
    {
        private readonly IAdminGamblingServices _AdminGambling;
        public AdminGamblingController(IAdminGamblingServices _adminGambling)
        {
            _AdminGambling = _adminGambling;
        }

        ///<summary>
        ///Traer Paises
        ///</summary>
        [HttpGet]
        [Route(nameof(AdminGamblingController.GetTeams))]
        public ResultResponse<List<Teams>> GetTeams() => _AdminGambling.GetTeams();

        ///<summary>
        ///Traer Partidos
        ///</summary>
        [HttpGet]
        [Route(nameof(AdminGamblingController.GetMatches))]
        public ResultResponse<List<GetMatchesDTO>> GetMatches() => _AdminGambling.GetMatches();


        ///<summary>
        ///Insertar Partidos al sistema
        ///</summary>
        [HttpPost]
        [Route(nameof(AdminGamblingController.InsertMatches))]
        public ResultResponse<string> InsertMatches(MatchesDTO matches) => _AdminGambling.InsertMatches(matches);

        ///<summary>
        ///Actualizar Partidos al sistema
        ///</summary>
        [HttpPut]
        [Route(nameof(AdminGamblingController.UpdateMatches))]
        public ResultResponse<string> UpdateMatches(UpdateMatchesDTO matches) => _AdminGambling.UpdateMatches(matches);

        ///<summary>
        ///Desactivar partido
        ///</summary>
        [HttpPut]
        [Route(nameof(AdminGamblingController.DisabledMatchById))]
        public ResultResponse<string> DisabledMatchById(DisabledMathcDTO idMatches) => _AdminGambling.DisabledMatchById(idMatches);
    }
}
