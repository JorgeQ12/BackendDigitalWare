using AutoMapper;
using GamblingBackDW.Domain.Entities;
using GamblingBackDW.Domain.Services.Interfaces.SessionGambling;
using GamblingBackDW.DTOs;

namespace GamblingBackDW.Domain.Services.SessionGambling
{
    public class SessionGamblingDomain : ISessionGamblingDomain
    {
        private readonly DbContextGamblingDW _context;
        public SessionGamblingDomain(DbContextGamblingDW context, IMapper mapper)
        {
            _context = context;
        }
        ///<summary>
        ///Traer Usuarios de la session
        ///</summary>
        public List<GetUsersSessionDTO> GetUserByMatch(string code)
        {
            try
            {
                return _context.Gamblings.Where(w => w.Session.SessionCode.Equals(code)).Select(x => new GetUsersSessionDTO()
                {
                    IdSessionDTO = x.SessionPerson.IdSession,
                    IdSessionPersonDTO = x.IdSessionPerson,
                    PersonIdentificationDTO = x.SessionPerson.PersonIdentification,
                    PersonNameDTO = x.SessionPerson.PersonName,
                    ScoreTeamADTO = x.ScoreTeamA,
                    ScoreTeamBDTO = x.ScoreTeamB
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Traer Partido y actualizaciones
        ///</summary>
        public GetMatchByCodeDTO GetMatchByCode(string code)
        {
            try
            {
                return _context.Session.Where(w => w.SessionCode.Equals(code)).Select(x => new GetMatchByCodeDTO()
                {
                    IdMatchDTO = x.IdMatches,
                    TeamADTO = x.Matches.TeamA.CountryName,
                    TeamBDTO = x.Matches.TeamB.CountryName,
                    ScoreTeamADTO = x.Matches.ScoreTeamA,
                    ScoreTeamBDTO = x.Matches.ScoreTeamB,
                    DateTimeMatchDTO = x.Matches.DateTime,
                    EnabledDTO = x.Matches.Enabled
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        ///<summary>
        ///Insertar Sessiones de partidos
        ///</summary>
        public string InsertSessionMatches(Session session)
        {
            try
            {
                _context.Session.Add(session);
                _context.SaveChanges();

                return session.SessionCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Traer ID de session activa
        ///</summary>
        public Guid? GetSessionByCode(string code)
        {
            try
            {
                Guid idSessionExist = _context.Session.Where(x => x.SessionCode.Equals(code)).FirstOrDefault().ID;
                return idSessionExist.Equals(Guid.Empty) ? null : idSessionExist;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Insertar Personas a sessiones de partidos
        ///</summary>
        public Guid InsertSessionPerson(SessionPerson sessionPerson)
        {
            try
            {
                _context.SessionPerson.Add(sessionPerson);
                _context.SaveChanges();

                return sessionPerson.ID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Insertar Apuestas por persona
        ///</summary>
        public Gamblings InsertGamblings(Gamblings gamblings)
        {
            try
            {
                _context.Gamblings.Add(gamblings);
                _context.SaveChanges();

                return gamblings;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Traer la apuesta del usuario
        ///</summary>
        public Gamblings GetGamblingByPerson(Guid sessionPerson)
        {
            try
            {
                return _context.Gamblings.Where(x => x.IdSessionPerson.Equals(sessionPerson)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///<summary>
        ///Actualizar la apuesta de usuario
        ///</summary>
        public Gamblings UpdateGamblingByPerson(Gamblings sessionPerson)
        {
            try
            {
                _context.Update(sessionPerson);
                _context.SaveChanges();
                return sessionPerson; 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
