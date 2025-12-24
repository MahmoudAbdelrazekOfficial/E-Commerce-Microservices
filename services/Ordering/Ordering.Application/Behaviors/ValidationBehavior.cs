using FluentValidation;
using MediatR;

namespace Ordering.Application.Behaviors
{
    //will collect fluent validations and run before handler
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                //will run all validation rules one by one and returns the validations result 
                var validationResult = await Task.WhenAll
                    (_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                //now need to check for any failure
                var failures = validationResult.SelectMany(e=>e.Errors).Where(f=>f !=null).ToList();

                if(failures.Count() > 0)
                {
                    throw new ValidationException(failures);
                }

            }
            return await next();
        }
    }
}
