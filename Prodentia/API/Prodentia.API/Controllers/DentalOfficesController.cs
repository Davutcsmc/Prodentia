using Microsoft.AspNetCore.Mvc;
using Prodentia.API.DTOs.DentalOffices;
using Prodentia.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using Prodentia.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using Prodentia.Application.Utilities;

namespace Prodentia.API.Controllers
{
    [ApiController]
    [Route("api/dentaloffices")]
    public class DentalOfficesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DentalOfficesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<DentalOfficesListDTO>>> Get()
        {
            var query = new GetDentalOfficesListQuery();
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DentalOfficeDetailDTO>> Get(Guid id)
        {
            var query = new GetDentalOfficeDetailQuery { Id = id };
            var result = await _mediator.Send(query);
            return result;
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateDentalOfficeDTO createDentalOfficeDTO)
        {
            var command = new CreateDentalOfficeCommand { Name = createDentalOfficeDTO.Name };
            var newId = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = newId }, newId); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateDentalOfficeDTO updateDentalOfficeDTO)
        {
            var command = new UpdateDentalOfficeCommand { Id = id, Name = updateDentalOfficeDTO.Name };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
