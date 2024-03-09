using MediatR;
using Persistence.Repository.Interfaces;

namespace Application.Feature.Fanger.Command.Slett
{
    public class SlettFangeCommandHandler : IRequestHandler<SlettFangeCommand, bool>
    {
        private readonly IFangerRepository _repo;

        public SlettFangeCommandHandler(IFangerRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(SlettFangeCommand request, CancellationToken cancellationToken)
        {
            var result = await _repo.SlettFange(request.FangeId);
            return result;
        }
    }

    public class SlettFangeCommand : IRequest<bool>
    {
        public int FangeId { get; }
        public SlettFangeCommand(int fangeId)
        {
            FangeId = fangeId;
        }
    }
}
