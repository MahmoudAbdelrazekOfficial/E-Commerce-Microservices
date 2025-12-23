using FluentValidation;
using Ordering.Application.Commands;

namespace Ordering.Application.Validators
{
    public class UpdateCheckoutOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateCheckoutOrderCommandValidator()
        {
            RuleFor(o => o.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("{Id} is required")
                .GreaterThan(0)
                .WithMessage("{Id} cann't be negative");

            RuleFor(o => o.UserName)
                .NotEmpty()
                .WithMessage("{UserName} is required")
                .NotNull()
                .MaximumLength(70)
                .WithMessage("User Name must not exceed 70 characters");

            RuleFor(o => o.TotalPrice)
                .NotEmpty()
                .WithMessage("total price is required")
                .GreaterThan(-1)
                .WithMessage("Total price shouldn't be negative");

            RuleFor(o => o.EmailAddress)
                .NotEmpty()
                .WithMessage("Email Address is required");

            RuleFor(o => o.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage("FirstName is required");

            RuleFor(o => o.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("LastName is required");
        }
    }
}
