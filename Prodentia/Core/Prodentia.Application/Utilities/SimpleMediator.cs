using FluentValidation;
using FluentValidation.Results;
using Prodentia.Application.Exceptions;

namespace Prodentia.Application.Utilities
{
    public class SimpleMediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public SimpleMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            await ApplyValidations(request);

            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

            var handler = _serviceProvider.GetService(handlerType);

            if (handler == null)
            {
                throw new MediatorException($"Handler not found for request type {request.GetType().Name}");
            }

            var method = handlerType.GetMethod("Handle");

            return await (Task<TResponse>)method.Invoke(handler, new object[] { request })!;
        }

        public async Task Send(IRequest request)
        {
            await ApplyValidations(request);

            var handlerType = typeof(IRequestHandler<>).MakeGenericType(request.GetType());

            var handler = _serviceProvider.GetService(handlerType);

            if (handler == null)
            {
                throw new MediatorException($"Handler not found for request type {request.GetType().Name}");
            }

            var method = handlerType.GetMethod("Handle");

            await (Task)method.Invoke(handler, new object[] { request })!;

        }

        private async Task ApplyValidations(object request)
        {
            var validatorType = typeof(IValidator<>).MakeGenericType(request.GetType());

            var validator = _serviceProvider.GetService(validatorType);

            if (validator is not null)
            {
                var validatorMethod = validatorType.GetMethod("ValidateAsync");
                var taskToValidate = (Task)validatorMethod!.Invoke(validator, new object[] { request, CancellationToken.None })!;

                await taskToValidate;

                var result = taskToValidate.GetType().GetProperty("Result");
                var validationResult = (ValidationResult)result!.GetValue(taskToValidate)!;

                //dynamic dynamicValidator = validator;
                //ValidationResult validationResult = await dynamicValidator.ValidateAsync((dynamic)request);

                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }
            }
        }
    }
}
