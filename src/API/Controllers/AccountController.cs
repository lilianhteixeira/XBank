using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
    public class AccountController : ControllerBase
    {
        private readonly IQueryRepository<Movement> _qRepository;
        private readonly ICommandRepository<Movement> _cmdMovementRepository;
        private readonly ICommandRepository<Account> _cmdAccountRepository;


        public AccountController(
            IQueryRepository<Movement> qRepository,
            ICommandRepository<Account> cmdAccountRepository,
            ICommandRepository<Movement> cmdMovementRepository
            )
        {
            _qRepository = qRepository;
            _cmdMovementRepository = cmdMovementRepository;
            _cmdAccountRepository = cmdAccountRepository;
        }

        [HttpPost]
        [Route("{id}")]
        public ActionResult Create([FromRoute] Guid id, [FromBody] AddMovementRequest request)
        {
            try
            {
                request.SetAccountId(id);

                var command = new AddAccountMovementCommandHandler(_cmdAccountRepository, _cmdMovementRepository);

                var result = command.Handle(request);

                return Created("", result);
            }
            catch (Exception exc)
            {
                return BadRequest(new { messageError = exc.Message });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetExtract([FromRoute] Guid id)
        {
            try
            {
                var query = new GetAccountMovementsHandler(_qRepository);

                var request = new GetByIdRequest();

                request.SetId(id);

                var result = query.Handle(request);

                //var options = new JsonSerializerOptions
                //{
                //    PropertyNameCaseInsensitive = true,
                    
                //};

                // var response = JsonSerializer.Serialize(result, options);

                return Ok(result);
            }
            catch (Exception exc)
            {
                return BadRequest(new { messageError = exc.Message });
            }
        }
    }
}
