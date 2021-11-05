using FluentValidation;
using System;
using WebAPI.Domain;

namespace WebAPI.Services.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(20)
                .WithMessage("Name can't be longer than 20 characters");

            RuleFor(x => x.Surname)
               .MaximumLength(20)
               .WithMessage("Surname can't be longer than 20 characters");

            RuleFor(x => x.BirthDate)
                .Must(date => BeAValidDate(date))
                .WithMessage("Birthday date must be less than today");

            RuleFor(x => x.UserTitleId)
                .GreaterThan(0)
                .WithMessage("User title identity must be greater then zero and not NULL");

            RuleFor(x => x.UserTypeId)
               .GreaterThan(0)
               .WithMessage("User type identity must be greater then zero and not NULL");

            RuleFor(x => x.EmailAddress)
               .MaximumLength(50)
               .WithMessage("Email can't be longer than 50 characters")
               .EmailAddress()
               .When(x => !string.IsNullOrWhiteSpace(x.EmailAddress))
               .WithMessage("Email is not in the right format \"name@domain.com\"");
        }

        /// <summary>Validate a user.</summary>
        /// <param name="user">The user.</param>
        /// <exception cref="System.ArgumentNullException">Entity cannot be null</exception>
        /// <exception cref="System.ArgumentException"></exception>
        public void ValidateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Entity cannot be null");
            }

            var validationResult = Validate(user);

            if (validationResult.IsValid == false)
            {
                throw new ArgumentException(validationResult.ToString());
            }
        }

        /// <summary>Check of date is valid.</summary>
        /// <param name="date">The date.</param>
        /// <returns><para>True for valid date, else false</para></returns>
        private bool BeAValidDate(DateTime? date)
        {
            if (!date.HasValue)
            {
                return true;
            }

            if (date.Value > DateTime.Today)
            {
                return false;
            }
            return true;
        }
    }
}
