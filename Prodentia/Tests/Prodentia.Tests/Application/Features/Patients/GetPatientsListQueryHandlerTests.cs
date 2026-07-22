using NSubstitute;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Features.Patients.Queries.GetPatientsList;
using Prodentia.Domain.Entities;
using Prodentia.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Tests.Application.Features.Patients
{
    [TestClass]
    public class GetPatientsListQueryHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public IPatientRepository _patientRepository;
        public GetPatientsListQueryHandler _handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            _patientRepository = Substitute.For<IPatientRepository>();
            _handler = new GetPatientsListQueryHandler(_patientRepository);
        }

        [TestMethod]
        public async Task Handle_ValidQuery_ReturnsPatientsPaginated()
        {
            var pageNumber = 1;
            var pageSize = 2;

            var patient1 = new Patient("Patient 01", new Email("patient01@example.com"));
            var patient2 = new Patient("Patient 02", new Email("patient02@example.com"));

            IEnumerable<Patient> patients = new List<Patient> { patient1, patient2 };

            _patientRepository.GetFilteredPatientsAsync(Arg.Any<PatientsFilterDTO>())
                .Returns(Task.FromResult(patients));

            _patientRepository.GetTotalAmountOfRecords().Returns(Task.FromResult(10));

            var query = new GetPatientsListQuery { PageNumber = pageNumber, PageSize = pageSize };

            var result = await _handler.Handle(query);

            Assert.AreEqual(10, result.TotalAmountOfRecords);
            Assert.HasCount(2, result.Items);

        }

        [TestMethod]
        public async Task Handle_WhenThereAreNoPatients_ReturnsEmptyListAndZero()
        {
            IEnumerable<Patient> patients = new List<Patient>();

            _patientRepository.GetFilteredPatientsAsync(Arg.Any<PatientsFilterDTO>())
                .Returns(Task.FromResult(patients));

            _patientRepository.GetTotalAmountOfRecords().Returns(Task.FromResult(0));

            var query = new GetPatientsListQuery { PageNumber = 1, PageSize = 2 };

            var result = await _handler.Handle(query);

            Assert.AreEqual(0, result.TotalAmountOfRecords);
            Assert.IsNotNull(result.Items);
            Assert.HasCount(0, result.Items);
        }


    }
}
