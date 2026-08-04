using Prodentia.Domain.Entities;

namespace Prodentia.Application.Contracts.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<bool> OverlapExists(Guid dentistId, DateTime startDate, DateTime endDate);
    }
}
