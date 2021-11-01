using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBank.Domain.Core.Commands;
using XBank.Domain.Core.Entities;
using XBank.Domain.Core.Requests;
using XBank.Domain.Shared.Interfaces;

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
            var command = new AddClientCommandHandler(_cmdRepository);

            var result = command.Handle(request);

            return Created("", result);
        }
    }
}
