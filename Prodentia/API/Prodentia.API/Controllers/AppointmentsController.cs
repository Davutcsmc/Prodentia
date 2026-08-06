using Microsoft.AspNetCore.Mvc;
using Prodentia.API.DTOs.Appointments;
using Prodentia.Application.Features.Appointments.Commands.CancelAppointment;
using Prodentia.Application.Features.Appointments.Commands.CompleteAppointment;
using Prodentia.Application.Features.Appointments.Commands.CreateAppointment;
using Prodentia.Application.Features.Appointments.Queries.GetAppointmentDetail;
using Prodentia.Application.Features.Appointments.Queries.GetAppointmentsList;
using Prodentia.Application.Features.Dentists.Queries.GetDentistDetail;
using Prodentia.Application.Utilities;

namespace Prodentia.API.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDetailDTO>> Get(Guid id)
        {
            var query = new GetAppointmentDetailQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<AppointmentsListDTO>>> Get([FromQuery] GetAppointmentListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAppointmentDTO createAppointmentDTO)
        {
            var command = new CreateAppointmentCommand
            {
                DentistId = createAppointmentDTO.DentistId,
                PatientId = createAppointmentDTO.PatientId,
                DentalOfficeId = createAppointmentDTO.DentalOfficeId,
                StartDate = createAppointmentDTO.StartDate,
                EndDate = createAppointmentDTO.EndDate
            };

            var result = await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("{id}/complete")]
        public async Task<IActionResult> Complete(Guid id)
        {
            var command = new CompleteAppointmentCommand
            {
                Id = id
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var command = new CancelAppointmentCommand { Id = id };

            await _mediator.Send(command);
            return NoContent();
        }


    }
}
