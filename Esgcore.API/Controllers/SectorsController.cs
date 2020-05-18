using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Esgcore.Logic.Sectors.Commands;
using Esgcore.Logic.Sectors.Queries;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Esgcore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SectorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSectors()
        {
            var query = new GetAllSectorsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{SectorId}")]
        public async Task<IActionResult> GetSector(long SectorId)
        {
            var query = new GetSectorByIdQuery(SectorId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateSector([FromBody] CreateSectorCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetSector), new { SectorId = result.Id }, result);
        }

    }
}