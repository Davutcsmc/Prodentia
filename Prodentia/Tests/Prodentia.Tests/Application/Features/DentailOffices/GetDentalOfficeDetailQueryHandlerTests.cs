using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Tests.Application.Features.DentailOffices
{
    [TestClass]
    public class GetDentalOfficeDetailQueryHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IDentalOfficeRepository _dentalOfficeRepository;
        private GetDentalOfficeDetailQueryHandler _handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            _dentalOfficeRepository = Substitute.For<IDentalOfficeRepository>();
            _handler = new GetDentalOfficeDetailQueryHandler(_dentalOfficeRepository);
        }

        [TestMethod]
        public async Task Handle_DentalOfficeExists_ReturnsIt()
        {
            var dentalOffice = new DentalOffice("Test Dental Office");
            var Id = dentalOffice.Id;
            var dentalOfficeQuery = new GetDentalOfficeDetailQuery { Id = Id };

            _dentalOfficeRepository.GetByIdAsync(dentalOfficeQuery.Id).Returns(dentalOffice);

            var result = await _handler.Handle(dentalOfficeQuery);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(dentalOffice.Id, result.Id);
            Assert.AreEqual("Test Dental Office", result.Name);
        }

        [TestMethod]
        public async Task Handle_DentalOfficeDoesNotExist_Throws()
        {
            var dentalOfficeQuery = new GetDentalOfficeDetailQuery { Id = Guid.NewGuid() };

            _dentalOfficeRepository.GetByIdAsync(dentalOfficeQuery.Id).ReturnsNull();

            await Assert.ThrowsExactlyAsync<NotFoundException>(async () => await _handler.Handle(dentalOfficeQuery));
        }
    }
}
