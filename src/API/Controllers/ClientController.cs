using Microsoft.AspNetCore.Mvc;
using System;
using XBank.Domain.Core.Commands;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Queries;
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
            try
            {
                var command = new AddAccountAndClientCommandHandler(_cmdRepository);

                var result = command.Handle(request);

                return Created("", result);

            }
            catch (InvalidOperationException exc)
            {
                return BadRequest(new { messageError = exc.Message });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateClientRequest request, [FromQuery] bool activate)
        {
            try
            {
                request.SetId(id);
                request.SetActivate(activate);

                var command = new UpdateClientCommandHandler(_cmdRepository);

                var result = command.Handle(request);

                return Ok(result);

            }
            catch (InvalidOperationException exc)
            {
                return BadRequest(new { messageError = exc.Message });
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove([FromRoute] Guid id, [FromBody] GetByIdRequest request)
        {
            try
            {
                request.SetId(id);

                var command = new RemoveAccountAndClientCommandHandler(_cmdRepository);

                command.Handle(request);

                return NoContent();
            }
            catch (InvalidOperationException exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] GetAllClientRequest request)
        {
            try
            {
                var query = new GetAllClientQueryHandler(_qRepository);

                var result = query.Handle(request);

                return Ok(result);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var query = new GetByIdQueryHandler<Client>(_qRepository);

                var request = new GetByIdRequest();
                request.SetId(id);

                var result = query.Handle(request);

                return Ok(result);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
