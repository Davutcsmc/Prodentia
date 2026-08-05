using Microsoft.EntityFrameworkCore;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Features.Appointments.Queries.GetAppointmentsList;
using Prodentia.Domain.Entities;
using Prodentia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Persistance.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly ProdentiaDbContext _context;
        public AppointmentRepository(ProdentiaDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<bool> OverlapExists(Guid dentistId, DateTime startDate, DateTime endDate)
        {
            return await _context.Appointments
                .AnyAsync<Appointment>(a => a.DentistId == dentistId 
                && a.Status == AppointmentStatus.Scheduled
                && a.TimeInterval.Start < endDate 
                && a.TimeInterval.End > startDate);
        }

        new public async Task<Appointment?> GetByIdAsync(Guid id)
        {
            return await _context.Appointments
                .Include(x=> x.Patient)
                .Include(x=> x.Dentist)
                .Include(x=> x.DentalOffice)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetFiltered(AppointmentsFilterDTO filter)
        {
            var query = _context.Appointments
                .Include(x => x.Patient)
                .Include(x => x.Dentist)
                .Include(x => x.DentalOffice)
                .AsQueryable();

            if (filter.DentalOfficeId.HasValue)
            {
                query = query.Where(a => a.DentalOfficeId == filter.DentalOfficeId.Value);
            }

            if (filter.PatientId.HasValue)
            {
                query = query.Where(a => a.PatientId == filter.PatientId.Value);
            }

            if (filter.DentistId.HasValue)
            {
                query = query.Where(a => a.DentistId == filter.DentistId.Value);
            }

            return await query
                .Where(x=> x.TimeInterval.Start >= filter.StartDate && x.TimeInterval.End <= filter.EndDate)
                .OrderBy(x=> x.TimeInterval.Start)
                .ToListAsync();
        }
    }
}
