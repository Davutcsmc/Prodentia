using Microsoft.AspNetCore.Mvc;
using Prodentia.API.DTOs.Patients;
using Prodentia.Application.Features.Patients.Commands.CreateCommand;
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
    }
}
