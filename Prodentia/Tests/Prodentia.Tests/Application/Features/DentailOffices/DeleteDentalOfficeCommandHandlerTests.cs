using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using Prodentia.Application.Contracts.Persistence;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Features.DentalOffices.Commands.DeleteDentalOffice;
using Prodentia.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Tests.Application.Features.DentailOffices
{
    [TestClass]
    public class DeleteDentalOfficeCommandHandlerTests
    {
        private IDentalOfficeRepository repository;
        private IUnitOfWork unitOfWork;
        private DeleteDentalOfficeCommandHandler handler;


        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IDentalOfficeRepository>();
            unitOfWork = Substitute.For<IUnitOfWork>();
            handler = new DeleteDentalOfficeCommandHandler(repository, unitOfWork);
        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeExists_DeleteAndCommitAreCalled()
        {
            var dentalOffice = new DentalOffice("Dental Office A001");
            var command = new DeleteDentalOfficeCommand() { Id = dentalOffice.Id };

            repository.GetByIdAsync(command.Id).Returns(dentalOffice);

            await handler.Handle(command);

            await repository.Received(1).DeleteAsync(dentalOffice);
            await unitOfWork.Received(1).Commit();
        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeNotExists_Throws()
        {
            var command = new DeleteDentalOfficeCommand() { Id = Guid.NewGuid() };

            repository.GetByIdAsync(command.Id).ReturnsNull();

            await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(command));
        }

        [TestMethod]
        public async Task Handle_WhenAnExceptionOccursWhileUpdating_RollbackIsCalled()
        {
            var dentalOffice = new DentalOffice("Dental Office A001");
            var command = new DeleteDentalOfficeCommand() { Id = dentalOffice.Id };

            repository.GetByIdAsync(command.Id).Returns(dentalOffice);
            repository.DeleteAsync(dentalOffice).Throws(new InvalidOperationException("Exception"));

            await Assert.ThrowsAsync<InvalidOperationException>(() => handler.Handle(command));

            await repository.Received(1).DeleteAsync(dentalOffice);
            await unitOfWork.Received(1).Rollback();
        }


    }
}
