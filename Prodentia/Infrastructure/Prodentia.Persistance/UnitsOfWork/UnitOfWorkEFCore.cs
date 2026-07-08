using Prodentia.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Persistance.UnitsOfWork
{
    public class UnitOfWorkEFCore : IUnitOfWork
    {
        private readonly ProdentiaDbContext _context;

        public UnitOfWorkEFCore(ProdentiaDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
