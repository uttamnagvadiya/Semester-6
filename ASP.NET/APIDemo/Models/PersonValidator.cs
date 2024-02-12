using FluentValidation;

namespace APIDemo.Models
{
    public class PersonValidator : AbstractValidator<PersonModel>
    {
        public PersonValidator() 
        {
            RuleFor(p => p.PersonName)
                .NotEmpty().WithMessage("Person Name is required.");
        }
    }
}
