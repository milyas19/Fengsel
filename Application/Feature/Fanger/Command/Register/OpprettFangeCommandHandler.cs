using AutoMapper;
using Entities;
using MediatR;
using Persistence;
using Persistence.Repository.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace Application.Feature.Fanger.Command.Register
{
    public class OpprettFangeCommandHandler : IRequestHandler<OpprettetFangeCommand, OpprettetFangeDto>
    {
        private readonly IFangerRepository _repo;
        private readonly IMapper _mapper;


        public OpprettFangeCommandHandler(IFangerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task<OpprettetFangeDto> Handle(OpprettetFangeCommand request, CancellationToken cancellationToken)
        {
            var fange = new Fange
            {
                Navn = request.Dto.Navn,
                Alder = request.Dto.Alder,
                Kjonn = request.Dto.Kjonn,
                FengslingsDatoFra = request.Dto.FengslingsDatoFra,
                FengslingsDatoTil = request.Dto.FengslingsDatoTil,
                CelleId = request.Dto.CelleId,
            };
            _repo.OpprettNyFanger(fange);

            var opprettetFangeDto = new OpprettetFangeDto
            {
                Id = fange.Id,
                Navn = fange.Navn,
                Alder = fange.Alder,
                Kjonn = fange.Kjonn,
                FengslingsDatoFra = fange.FengslingsDatoFra,
                FengslingsDatoTil = fange.FengslingsDatoTil,
                CelleId = fange.CelleId,
            };
            return Task.FromResult(opprettetFangeDto);
        }
    }

    public class OpprettetFangeCommand : IRequest<OpprettetFangeDto>
    {

        public OpprettetFangeCommand(OpprettFangeDto opprettFangeDto)
        {
            Dto = opprettFangeDto;
        }

        public OpprettFangeDto Dto { get; set; }
    }
}
