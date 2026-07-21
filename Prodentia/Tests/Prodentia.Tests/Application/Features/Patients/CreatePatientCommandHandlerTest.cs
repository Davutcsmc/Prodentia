using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using Prodentia.Application.Features.Patients.Commands.CreateCommand;
using Prodentia.Domain.Entities;
using Prodentia.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Tests.Application.Features.Patients
{
    [TestClass]
    public class CreatePatientCommandHandlerTest
    {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IPatientRepository _patientRepository;
        private IUnitOfWork _unitOfWork;
        private CreatePatientCommandHandler _handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            _patientRepository = Substitute.For<IPatientRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _handler = new CreatePatientCommandHandler(_patientRepository, _unitOfWork);
        }

        [TestMethod]
        public async Task Handle_ValidCommand_ReturnsPatientId()
        {
            var command = new CreatePatientCommand { Name = "testusername001", Email = "testusername001@email.com" };

            var patient = new Patient(command.Name, new Email(command.Email));

            _patientRepository.AddAsync(Arg.Any<Patient>()).Returns(patient);

            var result = await _handler.Handle(command);

            Assert.AreEqual(patient.Id, result);
            await _patientRepository.Received(1).AddAsync(Arg.Any<Patient>());
            await _unitOfWork.Received(1).Commit();
        }

        [TestMethod]
        public async Task Handle_WhenThereIsAnError_Rollback()
        {
            var command = new CreatePatientCommand { Name = "testusername001", Email = "testusername001@email.com" };

            _patientRepository.AddAsync(Arg.Any<Patient>()).Throws<Exception>();

            await Assert.ThrowsExactlyAsync<Exception>(async () =>
            {
                await _handler.Handle(command);
            });

            await _patientRepository.Received(1).AddAsync(Arg.Any<Patient>());
            await _unitOfWork.Received(1).Rollback();
        }


    }
}
