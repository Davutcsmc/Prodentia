using FluentValidation;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Prodentia.Application.Exceptions;
using Prodentia.Application.Utilities;
using Prodentia.Domain.Exceptions;
using Prodentia.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Tests.Application.Utilities.Mediator
{
    [TestClass]
    public class SimpleMediatorTests
    {
        public class FalseRequest : IRequest<string>
        {
            public required string Name { get; set; }
        }

        public class FalseRequestValidator : AbstractValidator<FalseRequest>
        {
            public FalseRequestValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                .NotNull().WithMessage("Name cannot be null.")
                .MaximumLength(200).WithMessage("Name cannot exceed 200 characters.");
            }
        }
        

        [TestMethod]
        public async Task Send_WithRegisteredHandler_HandleIsExecuted()
        {
            var request = new FalseRequest() { Name = "Test" };

            var handlerMock = Substitute.For<IRequestHandler<FalseRequest, string>>();

            var serviceProviderMock = Substitute.For<IServiceProvider>();

            serviceProviderMock.GetService(typeof(IRequestHandler<FalseRequest, string>)).Returns(handlerMock);

            var mediator = new SimpleMediator(serviceProviderMock);

            var result = await mediator.Send(request);

            await handlerMock.Received(1).Handle(request);
        }

        [TestMethod]
        public async Task Send_WithoutRegisteredHandler_Throws()
        {
            var request = new FalseRequest() { Name = "Test" };

            var serviceProviderMock = Substitute.For<IServiceProvider>();

            serviceProviderMock.GetService(typeof(IRequestHandler<FalseRequest, string>)).ReturnsNull();

            var mediator = new SimpleMediator(serviceProviderMock);

            var exception = await Assert.ThrowsExactlyAsync<MediatorException>(() => mediator.Send(request));
        }

        [TestMethod]

        public async Task Send_InvalidCommand_Throws()
        {
            var request = new FalseRequest() { Name = "" };

            var serviceProviderMock = Substitute.For<IServiceProvider>();
            serviceProviderMock.GetService(typeof(IValidator<FalseRequest>)).Returns(new FalseRequestValidator());

            var mediator = new SimpleMediator(serviceProviderMock);
            var exception = await Assert.ThrowsExactlyAsync<ValidationException>(() => mediator.Send(request));
        }
    }
}
