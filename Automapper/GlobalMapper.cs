using AutoMapper;
using GamblingBackDW.Domain.Entities;
using GamblingBackDW.DTOs;
using GamblingBackDW.Resources;

namespace GamblingBackDW.Automapper
{
    public class GlobalMapper : Profile
    {
        public GlobalMapper()
        {
            CreateMap<MatchesDTO, Matches>()
                .ForMember(target => target.ID, opt => opt.MapFrom(source => Guid.NewGuid()))
                .ForMember(target => target.IdTeamA, opt => opt.MapFrom(source => source.IdTeamADTO))
                .ForMember(target => target.IdTeamB, opt => opt.MapFrom(source => source.IdTeamBDTO))
                .ForMember(target => target.DateTime, opt => opt.MapFrom(source => source.DateTimeDTO))
                .ForMember(target => target.DateRegistration, opt => opt.MapFrom(source => DateTime.Now))
                .ForMember(target => target.Enabled, opt => opt.MapFrom(source => true));

            CreateMap<UpdateMatchesDTO, Matches>()
                .ForMember(target => target.ScoreTeamA, opt => opt.MapFrom(source => source.ScoreTeamADTO))
                .ForMember(target => target.ScoreTeamB, opt => opt.MapFrom(source => source.ScoreTeamBDTO));

            CreateMap<SessionDTO, Session>()
               .ForMember(target => target.ID, opt => opt.MapFrom(source => Guid.NewGuid()))
               .ForMember(target => target.IdMatches, opt => opt.MapFrom(source => source.IdMatchesDTO))
               .ForMember(target => target.SessionName, opt => opt.MapFrom(source => source.SessionNameDTO))
               .ForMember(target => target.SessionCode, opt => opt.MapFrom(source => SessionCodeGenerator.GenerateSessionCode(8)))
               .ForMember(target => target.Enabled, opt => opt.MapFrom(source => true));

            CreateMap<SessionPersonDTO, SessionPerson>()
               .ForMember(target => target.ID, opt => opt.MapFrom(source => Guid.NewGuid()))
               .ForMember(target => target.IdSession, opt => opt.MapFrom(source => source.IdSessionDTO))
               .ForMember(target => target.PersonIdentification, opt => opt.MapFrom(source => source.PersonIdentificationDTO))
               .ForMember(target => target.PersonName, opt => opt.MapFrom(source => source.PersonNameDTO));

            CreateMap<GamblingsDTO, Gamblings>()
              .ForMember(target => target.ID, opt => opt.MapFrom(source => Guid.NewGuid()))
              .ForMember(target => target.IdSession, opt => opt.MapFrom(source => source.IdSessionDTO))
              .ForMember(target => target.IdSessionPerson, opt => opt.MapFrom(source => source.IdSessionPersonDTO))
              .ForMember(target => target.ScoreTeamA, opt => opt.MapFrom(source => source.ScoreTeamADTO))
              .ForMember(target => target.ScoreTeamB, opt => opt.MapFrom(source => source.ScoreTeamBDTO))
              .ForMember(target => target.Enabled, opt => opt.MapFrom(source => true));


            CreateMap<UpdateSessionPersonDTO, Gamblings>()
              .ForMember(target => target.ScoreTeamA, opt => opt.MapFrom(source => source.ScoreTeamADTO))
              .ForMember(target => target.ScoreTeamB, opt => opt.MapFrom(source => source.ScoreTeamBDTO));

        }
    }
}
