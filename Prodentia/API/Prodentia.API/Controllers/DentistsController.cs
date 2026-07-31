using Microsoft.AspNetCore.Mvc;
using Prodentia.API.DTOs.Dentists;
using Prodentia.API.Utilities;
using Prodentia.Application.Features.Dentists.Commands.CreateDentist;
using Prodentia.Application.Features.Dentists.Commands.DeleteDentist;
using Prodentia.Application.Features.Dentists.Commands.UpdateDentist;
using Prodentia.Application.Features.Dentists.Queries.GetDentistDetail;
using Prodentia.Application.Features.Dentists.Queries.GetDentistsList;
using Prodentia.Application.Utilities;

namespace Prodentia.API.Controllers
{
    [ApiController]
    [Route("api/dentists")]
    public class DentistsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DentistsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<DentistListDTO>>> Get([FromQuery] GetDentistsListQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.AddPaginationHeader(result.TotalAmountOfRecords);
            return Ok(result.Items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DentistDetailDTO>> Get(Guid id)
        {
            var query = new GetDentistDetailQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDentistDTO createDentistDTO)
        {
            var command = new CreateDentistCommand
            {
                Name = createDentistDTO.Name,
                Email = createDentistDTO.Email
            };

            var result = await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateDentistDTO updateDentistDTO)
        {
            var command = new UpdateDentistCommand
            {
                Id = id,
                Name = updateDentistDTO.Name,
                Email = updateDentistDTO.Email
            };

            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteDentistCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
