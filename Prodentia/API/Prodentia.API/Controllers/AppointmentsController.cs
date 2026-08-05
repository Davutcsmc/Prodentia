using Microsoft.AspNetCore.Mvc;
using Prodentia.API.DTOs.Appointments;
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

        
    }
}
