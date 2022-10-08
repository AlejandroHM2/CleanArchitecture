using FluentValidation;

namespace Clean.Architecture.UseCases.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.Data.CustomerId)
                .NotEmpty()
                .WithMessage("Debe proporcionar el identificador del cliente.");
            RuleFor(c => c.Data.ShipAddress)
                .NotEmpty()
                .WithMessage("Debe proporcionar la dirección de envío.");
            RuleFor(c => c.Data.ShipCity)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Debe proporcionar al menos 3 caracteres del nombre de la ciudad.");
            RuleFor(c => c.Data.ShipCountry)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Debe proporcionar al menos 3 caracteres del nombre del país.");
            RuleFor(c => c.Data.OrderDetails)
                .Must(d => d.Any())
                .WithMessage("Deben especificarse los productos.");
        }
    }
}
