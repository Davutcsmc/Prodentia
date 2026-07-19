using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using Prodentia.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using Prodentia.Domain.Entities;
using Prodentia.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Tests.Application.Features.DentailOffices
{
    [TestClass]
    public class UpdateDentalOfficeCommandHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IDentalOfficeRepository _dentalOfficeRepository;
        private IUnitOfWork _unitOfWork;
        private UpdateDentalOfficeCommandHandler _updateDentalOfficeCommandHandler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            _dentalOfficeRepository = Substitute.For<IDentalOfficeRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _updateDentalOfficeCommandHandler = new UpdateDentalOfficeCommandHandler(_dentalOfficeRepository, _unitOfWork);
        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeExists_UpdatesIt()
        {
            // Arrange
            var dentalOffice = new DentalOffice("Test Dental Office");
            var command = new UpdateDentalOfficeCommand { Id = dentalOffice.Id, Name = "Updated Dental Office" };
            _dentalOfficeRepository.GetByIdAsync(command.Id).Returns(dentalOffice);
            // Act
            await _updateDentalOfficeCommandHandler.Handle(command);
            // Assert
            await _dentalOfficeRepository.Received(1).UpdateAsync(Arg.Is<DentalOffice>(d => d.Id == command.Id && d.Name == command.Name));
            await _unitOfWork.Received(1).Commit();

        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeDoesNotExist_ThrowsException()
        {
            // Arrange
            var command = new UpdateDentalOfficeCommand { Id = Guid.NewGuid(), Name = "Updated Dental Office" };
            _dentalOfficeRepository.GetByIdAsync(command.Id).ReturnsNull();
            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _updateDentalOfficeCommandHandler.Handle(command));
        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeNameIsInvalid_ThrowsException()
        {
            // Arrange
            var dentalOffice = new DentalOffice("Test Dental Office");
            var command = new UpdateDentalOfficeCommand { Id = dentalOffice.Id, Name = "" };
            _dentalOfficeRepository.GetByIdAsync(command.Id).Returns(dentalOffice);
            // Act & Assert
            await Assert.ThrowsAsync<BusinessRuleException>(() => _updateDentalOfficeCommandHandler.Handle(command));
        }

        [TestMethod]
        public async Task Handle_WhenExceptionOccured_RollbackIsCalled()
        {
            // Arrange
            var dentalOffice = new DentalOffice("Test Dental Office");
            var command = new UpdateDentalOfficeCommand { Id = dentalOffice.Id, Name = "Test Dental Office" };
            _dentalOfficeRepository.GetByIdAsync(command.Id).Returns(dentalOffice);
            _dentalOfficeRepository.UpdateAsync(Arg.Any<DentalOffice>()).ThrowsAsync(new Exception("Test exception"));
            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _updateDentalOfficeCommandHandler.Handle(command));
            await _unitOfWork.Received(1).Rollback();
        }

    }
}
