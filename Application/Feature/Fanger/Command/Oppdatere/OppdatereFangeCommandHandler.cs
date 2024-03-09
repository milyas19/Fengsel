using AutoMapper;
using Entities;
using MediatR;
using Persistence.Repository.Interfaces;

namespace Application.Feature.Fanger.Command.Oppdatere
{
    public class OppdatereFangeCommandHandler : IRequestHandler<OppdatereFangeCommand, OppdatereFangeDto>
    {
        private readonly IFangerRepository _repo;
        private readonly IMapper _mapper;

        public OppdatereFangeCommandHandler(IFangerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task<OppdatereFangeDto> Handle(OppdatereFangeCommand request, CancellationToken cancellationToken)
        {
            var fange = new Fange
            {
                Id = request.Dto.Id,
                Navn = request.Dto.Navn,
                Alder = request.Dto.Alder,
                Kjonn = request.Dto.Kjonn,
                FengslingsDatoFra = request.Dto.FengslingsDatoFra,
                FengslingsDatoTil = request.Dto.FengslingsDatoTil,
                CelleId = request.Dto.CelleId,
            };
            var oppdatertFange = _repo.OppdatertFanger(fange);
            var mappedFangeObj = Task.FromResult(_mapper.Map<OppdatereFangeDto>(oppdatertFange));
            return mappedFangeObj;
        }
    }

    public class OppdatereFangeCommand : IRequest<OppdatereFangeDto>
    {
        public OppdatereFangeCommand(OppdatereFangeDto oppdatereFangeDto)
        {
            Dto = oppdatereFangeDto;
        }

        public OppdatereFangeDto Dto { get; }
    }
}
