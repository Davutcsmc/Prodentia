using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Tests.Application.Features.DentailOffices
{
    [TestClass]
    public class CreateDentalOfficeCommandHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IDentalOfficeRepository _dentalOfficeRepository;
        private IUnitOfWork _unitOfWork;
        private CreateDentalOfficeCommandHandler _createDentalOfficeCommandHandler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            _dentalOfficeRepository = Substitute.For<IDentalOfficeRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _createDentalOfficeCommandHandler = new CreateDentalOfficeCommandHandler(_dentalOfficeRepository, _unitOfWork);
        }

        [TestMethod]
        public async Task Handle_ValidCommand_ReturnsDentalOfficeId()
        {
            // Arrange
            var command = new CreateDentalOfficeCommand { Name = "Test Dental Office" };

            var dentalOffice = new DentalOffice(command.Name);

            _dentalOfficeRepository.AddAsync(Arg.Any<DentalOffice>())
                .Returns(dentalOffice);

            var result = await _createDentalOfficeCommandHandler.Handle(command);

            await _dentalOfficeRepository.Received(1).AddAsync(Arg.Any<DentalOffice>());
            await _unitOfWork.Received(1).Commit();

            Assert.AreEqual(dentalOffice.Id, result);
        }

        [TestMethod]
        public async Task Handle_WhenTheresAnError_Rollback()
        {
            var command = new CreateDentalOfficeCommand { Name = "Test Dental Office" };

            _dentalOfficeRepository.AddAsync(Arg.Any<DentalOffice>())
                .Throws<Exception>();

            await Assert.ThrowsExactlyAsync<Exception>(async () =>
            {
                await _createDentalOfficeCommandHandler.Handle(command);
            });

            await _unitOfWork.Received(1).Rollback();
        }

    }
}
