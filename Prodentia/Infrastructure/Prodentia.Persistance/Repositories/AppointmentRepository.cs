using Microsoft.EntityFrameworkCore;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Domain.Entities;
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
                && a.TimeInterval.Start < endDate 
                && a.TimeInterval.End > startDate);
        }
    }
}
