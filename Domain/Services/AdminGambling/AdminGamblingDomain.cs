using GamblingBackDW.Domain.Entities;
using GamblingBackDW.Domain.Services.Interfaces.AdminGambling;
using GamblingBackDW.DTOs;

namespace GamblingBackDW.Domain.Services.AdminGambling
{
    public class AdminGamblingDomain : IAdminGamblingDomain
    {
        private readonly DbContextGamblingDW _context;
        public AdminGamblingDomain(DbContextGamblingDW context)
        {
            _context = context;
        }

        ///<summary>
        ///Traer Paises
        ///</summary>
        public List<Teams> GetTeams()
        {
            try
            {
                return _context.Teams.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Traer Partidos
        ///</summary>
        public List<GetMatchesDTO> GetMatches()
        {
            try
            {
                return _context.Matches.Where(x => x.Enabled).Select(x => new GetMatchesDTO()
                {
                    IdDTO = x.ID,
                    IdTeamADTO = x.IdTeamA,
                    NameTemaADTO = x.TeamA.CountryName,
                    IdTeamBDTO = x.IdTeamB,
                    NameTemaBDTO = x.TeamB.CountryName,
                    ScoreTeamA = x.ScoreTeamA,
                    ScoreTeamB = x.ScoreTeamB,
                    DateTime = x.DateTime,
                    Enabled = x.Enabled
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Insertar Partidos al sistema
        ///</summary>
        public Matches InsertMatches(Matches matches)
        {
            try
            {
                _context.Add(matches);
                _context.SaveChanges();
                return matches;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Actualizar Partidos al sistema
        ///</summary>
        public Matches UpdateMatches(Matches matches)
        {
            try
            {
                _context.Update(matches);
                _context.SaveChanges();

                return matches;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Validar si existe el Match
        ///</summary>
        public Matches GetMatchById(Guid idMatch)
        {
            try
            {
                return _context.Matches.Where(x => x.ID.Equals(idMatch)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Desactivar partido
        ///</summary>
        public Matches DisabledMatchById(Matches idMatches)
        {
            try
            {
                _context.Update(idMatches);
                _context.SaveChanges();
                return idMatches;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
