using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeyManagement.Logic.Commands;
using KeyManagement.Logic.Queries;
using KeyManagement.Repository.Entities;
using KeyManagment.Bus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KeyManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeySetsController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public KeySetsController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpGet()]
        public async Task<IEnumerable<KeySet>> Get([FromQuery] GetKeySetParams getKeySetParams)
        {
            return (await _queryBus.ExecuteQuery(GetKeySets.Create(getKeySetParams))).Response;
        }

        [HttpPost]
        public async Task Post([FromBody] CreateKeySetParams createKeySetParams)
        {
            await _commandBus.ExecuteCommand(CreateKeySet.Create(createKeySetParams));
        }
    }
}
