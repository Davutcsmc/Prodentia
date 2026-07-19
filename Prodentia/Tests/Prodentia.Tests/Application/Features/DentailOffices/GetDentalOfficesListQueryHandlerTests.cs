using NSubstitute;
using Prodentia.Application.Contracts.Repositories;
using Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using Prodentia.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using Prodentia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Prodentia.Tests.Application.Features.DentailOffices
{
    [TestClass]
    public class GetDentalOfficesListQueryHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IDentalOfficeRepository _dentalOfficeRepository;
        private GetDentalOfficesListQueryHandler _getDentalOfficesListQueryHandler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            _dentalOfficeRepository = Substitute.For<IDentalOfficeRepository>();
            _getDentalOfficesListQueryHandler = new GetDentalOfficesListQueryHandler(_dentalOfficeRepository);
        }

        [TestMethod]
        public async Task Handle_WhenThereAreDentalOffices_ReturndListOfThem()
        {
            var dentalOffices = new List<DentalOffice>
            {
                new DentalOffice("Dental Office A"),
                new DentalOffice("Dental Office B")
            };

            var dentalOfficeListQuery = new GetDentalOfficesListQuery();

            _dentalOfficeRepository.GetAllAsync().Returns(dentalOffices);

            var expected = dentalOffices.Select(d => new DentalOfficesListDTO 
            { 
                Id = d.Id, 
                Name = d.Name 
            }).ToList();

            var result = await _getDentalOfficesListQueryHandler.Handle(dentalOfficeListQuery);

            // Assert
            Assert.HasCount(expected.Count, result);
            for (int i = 0; i<expected.Count; i++ )
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Name, result[i].Name);
            }
        }

        [TestMethod]
        public async Task Handle_WhenThereAreNoDentalOffices_ReturnsEmptyList()
        {
            var dentalOfficeListQuery = new GetDentalOfficesListQuery();

            _dentalOfficeRepository.GetAllAsync().Returns(new List<DentalOffice>());

            var result = await _getDentalOfficesListQueryHandler.Handle(dentalOfficeListQuery);

            Assert.IsNotNull(result);
            Assert.HasCount(0, result);
        }
    }
}
