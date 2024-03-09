using Application.Feature.Celle;
using AutoMapper;
using MediatR;
using Persistence.Repository.Interfaces;

namespace Application.Feature.Celler.Query.HentLedigCeller
{
    public class HentLedigCellerQueryHandler : IRequestHandler<HentLedigCellerQuery, List<CelleDto>>
    {
        private readonly ICelleRepository _repo;
        private readonly IMapper _mapper;

        public HentLedigCellerQueryHandler(ICelleRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CelleDto>> Handle(HentLedigCellerQuery request, CancellationToken cancellationToken)
        {
            var ledigCeller = await _repo.HentLedigCeller();
            return _mapper.Map<List<CelleDto>>(ledigCeller);
        }
    }

    public class HentLedigCellerQuery : IRequest<List<CelleDto>>
    {
    }
}
