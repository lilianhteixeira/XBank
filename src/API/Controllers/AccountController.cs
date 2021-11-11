using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using XBank.Domain.Core.Commands;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Queries;
using XBank.Domain.Core.Requests;
using XBank.Domain.Shared.Interfaces;
using XBank.Domain.Shared.Requests;

namespace XBank.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IQueryRepository<Movement> _qRepository;
        private readonly IQueryRepository<Account> _qAccountRepository;
        private readonly ICommandRepository<Movement> _cmdMovementRepository;
        private readonly ICommandRepository<Account> _cmdAccountRepository;


        public AccountController(
            IQueryRepository<Movement> qRepository,
            IQueryRepository<Account> qAccountRepository,
            ICommandRepository<Account> cmdAccountRepository,
            ICommandRepository<Movement> cmdMovementRepository
            )
        {
            _qRepository = qRepository;
            _qAccountRepository = qAccountRepository;
            _cmdMovementRepository = cmdMovementRepository;
            _cmdAccountRepository = cmdAccountRepository;
        }

        [HttpPost]
        [Route("{id}")]
        public ActionResult Add([FromRoute] Guid id, [FromBody] AddMovementRequest request)
        {

            request.SetAccountId(id);

            var command = new AddAccountMovementCommandHandler(_cmdAccountRepository, _cmdMovementRepository);

            var result = command.Handle(request);

            return Created("", result);

        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            var query = new GetAccountHandler(_qAccountRepository);
            var request = new GetByIdRequest();
            request.SetId(id);

            var result = query.Handle(request);

            return Ok(result);
        }


        [HttpGet]
        [Route("{id}/extract")]
        public ActionResult GetExtract([FromRoute] Guid id)
        {

            var query = new GetAccountMovementsHandler(_qRepository);

            var request = new GetByIdRequest();

            request.SetId(id);

            var result = query.Handle(request);


            var response = JsonSerializer.Serialize(result);

            return Ok(response);
        }

    }
}
