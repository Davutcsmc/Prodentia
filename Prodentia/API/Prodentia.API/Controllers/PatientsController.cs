using Microsoft.AspNetCore.Mvc;
using Prodentia.API.DTOs.Patients;
using Prodentia.API.Utilities;
using Prodentia.Application.Features.DentalOffices.Commands.DeleteDentalOffice;
using Prodentia.Application.Features.Patients.Commands.CreateCommand;
using Prodentia.Application.Features.Patients.Commands.DeletePatient;
using Prodentia.Application.Features.Patients.Commands.UpdatePatient;
using Prodentia.Application.Features.Patients.Queries;
using Prodentia.Application.Features.Patients.Queries.GetPatientDetail;
using Prodentia.Application.Features.Patients.Queries.GetPatientsList;
using Prodentia.Application.Utilities;

namespace Prodentia.API.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientListDTO>>> Get([FromQuery] GetPatientsListQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.AddPaginationHeader(result.TotalAmountOfRecords);
            return Ok(result.Items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDetailDTO>> Get(Guid id)
        {
            var query = new GetPatientDetailQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePatientDTO createPatientDTO)
        {
            var command = new CreatePatientCommand 
            {
                Name = createPatientDTO.Name,
                Email = createPatientDTO.Email
            };

            var result = await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdatePatientDTO updatePatientDTO)
        {
            var command = new UpdatePatientCommand
            {
                Id = id,
                Name = updatePatientDTO.Name,
                Email = updatePatientDTO.Email
            };

            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePatientCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
