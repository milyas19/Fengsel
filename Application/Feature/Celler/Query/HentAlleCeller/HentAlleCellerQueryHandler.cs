using MediatR;
using Persistence.Repository.Interfaces;
using AutoMapper;
using Application.Feature.Celle;


namespace Application.Feature.Celler.Query.HentAlleCeller
{
    public class HentAlleCellerQueryHandler : IRequestHandler<HentAlleCellerQuery, List<CelleDto>>
    {
        private readonly ICelleRepository _repo;
        private readonly IMapper _mapper;

        public HentAlleCellerQueryHandler(ICelleRepository repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CelleDto>> Handle(HentAlleCellerQuery request, CancellationToken cancellationToken)
        {
            var celleList = await _repo.HentCeller();
            var mappedCeller = _mapper.Map<List<CelleDto>>(celleList);
            return mappedCeller;
        }
    }

    public class HentAlleCellerQuery : IRequest<List<CelleDto>>
    {
    }
}
