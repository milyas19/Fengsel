using Application.Feature.Celle;
using Application.Feature.Celler.Command;
using Application.Feature.Celler.Query.HentAlleCeller;
using Application.Feature.Celler.Query.HentCelleAvId;
using Application.Feature.Celler.Query.HentLedigCeller;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class CelleController : ControllerBase
    {
        private readonly ILogger<CelleController> _logger;
        private readonly IMediator _mediator;

        public CelleController(ILogger<CelleController> logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpGet("{celleId}")]
        public async Task<ActionResult<CelleDto>> HentCelleAvId(int celleId)
        {
            var celle = await _mediator.Send(new HentCelleAvIdQuery(celleId));
            return Ok(celle);
        }

        [HttpGet]
        public async Task<ActionResult<List<CelleDto>>> HentCeller()
        {
            var celler = await _mediator.Send(new HentAlleCellerQuery());
            return Ok(celler);
        }

        [HttpGet("ledig")]
        public async Task<ActionResult<List<CelleDto>>> HentLedigCeller()
        {
            var ledigCeller = await _mediator.Send(new HentLedigCellerQuery());
            return Ok(ledigCeller);
        }

        [HttpPost]
        public async Task<ActionResult<CelleDto>> OpprettCelle(CelleDto celleDto)
        {
            var celle = await _mediator.Send(new OpprettCelleCommand(celleDto));
            return Ok(celle);
        }
    }
}
