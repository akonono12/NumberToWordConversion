using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConversion.Application.Conversions.Commands
{
    public class ConvertNumberToWordCommandValidator: AbstractValidator<ConvertNumberToWordCommand>
    {
        public ConvertNumberToWordCommandValidator()
        {
            RuleFor(x => x.Number)
            .NotNull()
            .NotEmpty()
            .WithMessage("Input must not be empty");

            RuleFor(x => x.Number)
            .Must(IsNumber)
            .WithMessage("Input must be a number")
            .When(x => !string.IsNullOrEmpty(x.Number));

            RuleFor(x => x.Number)
            .Must(IsPositiveNumber)
            .WithMessage("Input must be greater than zero")
            .When(x => !string.IsNullOrEmpty(x.Number) && IsNumber(x.Number));
        }

        private bool IsNumber(string value)
        {
            if (!Decimal.TryParse(value, out decimal num))
            {
                return false;
            }
            return true;
        }

        private bool IsPositiveNumber(string value)
        {
            var num = Convert.ToDecimal(value);
            if(num <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
