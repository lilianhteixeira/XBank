﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Add([FromBody] ClientRequest request)
        {
            try
            {
                var command = new OpenAccountCommandHandler(_cmdRepository);

                var result = command.Handle(request);

                return Created("", result);

            }
            catch (InvalidOperationException exc)
            {
                return BadRequest(new { messageError = exc.Message });
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] ClientRequest request, [FromQuery] bool activate)
        {
            try
            {
                var command = new UpdateClientCommandHandler(_cmdRepository);

                var result = command.Handle(request);

                return Ok(result);

            }
            catch (Exception)
            {
                return BadRequest("Cliente não encontrado. Digite um CPF válido.");
            }
        }


        [HttpDelete]
        public IActionResult Remove([FromBody] RemoveAccountRequest request)
        {
            try
            {
                var command = new RemoveAccountCommandHandler(_cmdRepository);

                command.Handle(request);

                return NoContent();
            }
            catch (Exception exc)
            {

                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] GetAllClientRequest request)
        {
            var query = new GetAllClientQueryHandler(_qRepository);

            var result = query.Handle(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var query = new GetByIdQueryHandler<Client>(_qRepository);

            var request = new GetByIdRequest() { Id = id };

            var result = query.Handle(request);

            return Ok(result);
        }
    }
}
