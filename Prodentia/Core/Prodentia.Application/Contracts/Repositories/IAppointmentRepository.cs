using Prodentia.Application.Features.Appointments.Queries.GetAppointmentsList;
using Prodentia.Domain.Entities;

namespace Prodentia.Application.Contracts.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<bool> OverlapExists(Guid dentistId, DateTime startDate, DateTime endDate);

        new Task<Appointment?> GetByIdAsync(Guid id);

        Task<IEnumerable<Appointment>> GetFiltered(AppointmentsFilterDTO filter);

    }
}
