using Application.Credit.Commands;
using Application.Credit.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditsController : ControllerBase
    {
        readonly IMediator _mediator;
        public CreditsController(IMediator mediator) => this._mediator = mediator;

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            GetCreditDto value = await _mediator.Send(new GetCreditQuery { Id = id });
            return Ok(value);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int page,int size)
        {
            GetAllCreditDto value = await _mediator.Send(new GetAllCreditQuery{ Page = page , Size = size} );
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCreditCommand command)
        {
            await _mediator.Send(command);
            return Ok(command);
        }
    }
}
