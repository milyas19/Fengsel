using Application.Feature.Celle;
using Application.Feature.Fanger.Command.Oppdatere;
using Application.Feature.Fanger.Command.Register;
using Application.Feature.Fanger.Query.Hent;
using AutoMapper;
using Entities;

namespace API.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Celle, CelleDto>();
            CreateMap<Fange, OpprettetFangeDto>().ReverseMap();
            CreateMap<Fange, OpprettFangeDto>().ReverseMap();
            CreateMap<Fange, OppdatereFangeDto>().ReverseMap();
            CreateMap<Fange, HentFangerDto>().ReverseMap();
        }
    }
}
