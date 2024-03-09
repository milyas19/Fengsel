using Application.Feature.Celle;
using AutoMapper;
using MediatR;
using Persistence.Repository.Interfaces;

namespace Application.Feature.Celler.Query.HentCelleAvId
{
    public class HentCelleAvIdQueryHandler : IRequestHandler<HentCelleAvIdQuery, CelleDto>
    {
        private readonly ICelleRepository _repo;
        private readonly IMapper _mapper;

        public HentCelleAvIdQueryHandler(ICelleRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CelleDto> Handle(HentCelleAvIdQuery request, CancellationToken cancellationToken)
        {
            var celleInfo = await _repo.HentCelleAvId(request.Id);
            return _mapper.Map<CelleDto>(celleInfo);
        }
    }

    public class HentCelleAvIdQuery : IRequest<CelleDto>
    {
        public HentCelleAvIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
