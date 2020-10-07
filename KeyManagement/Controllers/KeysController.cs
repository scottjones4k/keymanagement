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
    public class KeysController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public KeysController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpGet()]
        public async Task<IEnumerable<Key>> Get([FromQuery] GetKeysParams getKeySetParams)
        {
            return (await _queryBus.ExecuteQuery(GetKeys.Create(getKeySetParams))).Response;
        }

        [HttpGet("{id}")]
        public async Task<Key> Get([FromRoute] string id)
        {
            return (await _queryBus.ExecuteQuery(GetKey.Create(new GetKeyParams
            {
                KeyId = id
            }))).Response;
        }

        [HttpPost]
        public async Task Post([FromBody] CreateKeyParams createKeyParams)
        {
            await _commandBus.ExecuteCommand(CreateKey.Create(createKeyParams));
        }
    }
}
