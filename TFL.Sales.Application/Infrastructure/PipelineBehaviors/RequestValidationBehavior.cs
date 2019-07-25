using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace TFL.Sales.Application.Infrastructure.PipelineBehaviors
{
	public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	{
		private readonly IValidatorFactory _validationFactory;

		public RequestValidationBehavior(IValidatorFactory validationFactory)
		{
			_validationFactory = validationFactory;
		}

		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			var validator = _validationFactory.GetValidator(request.GetType());
			var result = validator?.Validate(request);

			if (result != null && !result.IsValid)
				throw new ValidationException(result.Errors);

			var response = await next();

			return response;
		}
	}
}