using FluentValidation;
using MediatR;
using NumberToWordConversion.Application.Shared.Results;
using NumberToWordConversion.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConversion.Application.Conversions.Commands
{
    internal class ConvertNumberToWordCommandHandler : IRequestHandler<ConvertNumberToWordCommand, CommandResult<string>>
    {
        private readonly INumberToWordService _numberToWordService;
        private readonly IValidator<ConvertNumberToWordCommand> _validator;

        public ConvertNumberToWordCommandHandler(INumberToWordService numberToWordService, IValidator<ConvertNumberToWordCommand> validator)
        {
            _numberToWordService = numberToWordService;
            _validator = validator;
        }
        public async Task<CommandResult<string>> Handle(ConvertNumberToWordCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return new CommandResult<string> { Success = false, Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList() };
            }
            var result = new CommandResult<string> { Success = true, Data = _numberToWordService.Convert(Convert.ToDecimal(request.Number)) };
            return result;
        }
    }
}
