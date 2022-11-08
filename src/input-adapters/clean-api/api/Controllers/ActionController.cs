using Clean.Application.Port.Commands;
using Clean.Domain.Port.Model.Aggregate.Value;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers
{
    [ApiController]
    [Route("action")]
    public class ActionController : ControllerBase
    {
        private readonly ISender _sender;

        public ActionController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [Route("ping")]
        public async Task<IActionResult> Ping()
        {
            var id = await _sender.Send(new PingCommand());
            return Created("", id);
        }

        [HttpPatch]
        [Route("pong/{id}")]
        public async Task<IActionResult> Pong(Guid id)
        {
            await _sender.Send(new PongCommand(ActionId.From(id)));
            return Ok();
        }
    }
}
