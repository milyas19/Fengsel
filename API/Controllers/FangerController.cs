using Application.Feature.Fanger.Command.Oppdatere;
using Application.Feature.Fanger.Command.Register;
using Application.Feature.Fanger.Command.Slett;
using Application.Feature.Fanger.Query.Hent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class FangerController : ControllerBase
    {
        private readonly ILogger<FangerController> _logger;
        private readonly IMediator _mediator;

        public FangerController(ILogger<FangerController> logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<HentFangerDto>>> HentFanger()
        {
            var fanger = await _mediator.Send(new HentFangerQuery());
            return Ok(fanger);
        }

        [HttpPost]
        public async Task<ActionResult<OpprettetFangeDto>> OppretteFange(OpprettFangeDto opprettFangeDto)
        {
            var nyFange = await _mediator.Send(new OpprettetFangeCommand(opprettFangeDto));
            return Ok(nyFange);
        }

        [HttpPut]
        public async Task<ActionResult<OppdatereFangeDto>> OppdaterFange(OppdatereFangeDto oppdatereFangeDto)
        {
            var nyFange = await _mediator.Send(new OppdatereFangeCommand(oppdatereFangeDto));
            return Ok(nyFange);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> SlettFange(int id)
        {
            var nyFange = await _mediator.Send(new SlettFangeCommand(id));
            return Ok(nyFange);
        }


    }
}
