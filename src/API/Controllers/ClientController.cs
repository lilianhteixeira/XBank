using Microsoft.AspNetCore.Mvc;
using System;
using XBank.Domain.Core.Commands;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Requests;
using XBank.Domain.Shared.Handlers;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Requests;

namespace XBank.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IQueryRepository<Client> _qRepository;
        private readonly ICommandRepository<Client> _cmdRepository;


        public ClientController(IQueryRepository<Client> qRepository, ICommandRepository<Client> cmdRepository)
        {
            _qRepository = qRepository;
            _cmdRepository = cmdRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddClientRequest request)
        {

            var command = new AddAccountAndClientCommandHandler(_cmdRepository);

            var result = command.Handle(request);

            return Created("", result);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateClientRequest request, [FromQuery] bool activate)
        {
            request.SetId(id);
            request.SetActivate(activate);

            var command = new UpdateClientCommandHandler(_cmdRepository);

            var result = command.Handle(request);

            return Ok(result);
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove([FromRoute] Guid id)
        {
            var request = new GetByIdRequest();

            request.SetId(id);

            var command = new RemoveAccountAndClientCommandHandler(_cmdRepository);

            command.Handle(request);

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var query = new GetByIdQueryHandler<Client>(_qRepository);

            var request = new GetByIdRequest();
            request.SetId(id);

            var result = query.Handle(request);

            return Ok(result);
        }
    }
}
