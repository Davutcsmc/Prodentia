using Prodentia.Application.Contracts.Repositories;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Persistance.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(ProdentiaDbContext context) : base(context)
        {
        }
    }
}
