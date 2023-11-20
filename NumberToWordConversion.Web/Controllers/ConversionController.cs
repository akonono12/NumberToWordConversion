using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NumberToWordConversion.Application.Conversions.Commands;

namespace NumberToWordConversion.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ConversionController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet("{number}")]
        public async Task<IActionResult> ConvertToWord([FromRoute] string number)
        {
            var request = new ConvertNumberToWordCommand()
            {
                Number = number
            };
            return Ok(await _mediator.Send(request));
        }
    }
}
