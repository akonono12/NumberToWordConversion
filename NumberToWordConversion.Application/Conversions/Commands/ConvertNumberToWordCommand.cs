using MediatR;
using NumberToWordConversion.Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConversion.Application.Conversions.Commands
{
    public class ConvertNumberToWordCommand:IRequest<CommandResult<string>>
    {
        public string Number { get; set; }
    }
}
