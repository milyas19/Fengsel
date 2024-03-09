using AutoMapper;
using MediatR;
using Persistence.Repository.Interfaces;

namespace Application.Feature.Fanger.Query.Hent
{
    public class HentFangerCommandHandler : IRequestHandler<HentFangerQuery, List<HentFangerDto>>
    {
        private readonly IFangerRepository _repo;
        private readonly IMapper _mapper;

        public HentFangerCommandHandler(IFangerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<HentFangerDto>> Handle(HentFangerQuery request, CancellationToken cancellationToken)
        {
            var fanger = await _repo.HentFangerList();
            return _mapper.Map<List<HentFangerDto>>(fanger);
        }
    }

    public class HentFangerQuery : IRequest<List<HentFangerDto>>
    {

    }
}
