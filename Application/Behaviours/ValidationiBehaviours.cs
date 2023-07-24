using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Behaviours
{
    public class ValidationiBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationiBehaviours(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var ValidateResult = await Task.WhenAll(_validators.Select(
                                    validator => validator.ValidateAsync(context, cancellationToken)));
                var failures = ValidateResult.SelectMany(
                                error => error.Errors)
                                .Where(fail => fail != null).ToList();
                if (failures.Count != 0)
                {
                    throw new Exceptions.ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
