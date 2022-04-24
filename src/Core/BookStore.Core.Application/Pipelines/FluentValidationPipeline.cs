using BookStore.Core.Application.Responses;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Core.Application.Pipelines
{

    public class FluentValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : BaseResponse
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public FluentValidationPipeline(IEnumerable<IValidator<TRequest>> validators)
        {
            this._validators = validators;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationFailures = _validators
           .Select(validator => validator.Validate(request))
           .SelectMany(validationResult => validationResult.Errors)
           .Where(validationFailure => validationFailure != null)
           .ToList();

            if (validationFailures.Any())
            {
                var error = string.Join("\r\n", validationFailures);
                throw new BookStore.Core.Application.Exceptions.ValidationException(validationFailures);
            }

            return next();
        }
    }
}
