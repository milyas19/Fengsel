using AutoMapper;
using MediatR;
using Persistence.Repository.Interfaces;
using Application.Feature.Celle;
namespace Application.Feature.Celler.Command
{
    public class OpprettCelleCommandHandler : IRequestHandler<OpprettCelleCommand, CelleDto>
    {
        private readonly ICelleRepository _repo;
        private readonly IMapper _mapper;

        public OpprettCelleCommandHandler(ICelleRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task<CelleDto> Handle(OpprettCelleCommand request, CancellationToken cancellationToken)
        {
            var celle = new Entities.Celle
            {
                Id = request.Dto.Id,
                CelleNumber = request.Dto.CelleNumber,
                Opptatt = request.Dto.Opptatt
            };
            var opprettetCelle = _repo.OpprettCell(celle);

            var oprettetCelleDto = new CelleDto
            {
                Id = opprettetCelle.Id,
                CelleNumber = opprettetCelle.CelleNumber,
                Opptatt = opprettetCelle.Opptatt
            };

            return Task.FromResult(oprettetCelleDto);
        }
    }

    public class OpprettCelleCommand : IRequest<CelleDto>
    {
        public OpprettCelleCommand(CelleDto celleDto)
        {
            Dto = celleDto;
        }

        public CelleDto Dto { get; set; }
    }
}
