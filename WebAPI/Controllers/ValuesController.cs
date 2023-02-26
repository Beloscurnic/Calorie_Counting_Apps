using Application.Requests.Commands.Creat_Exemple;
using Application.Requests.Queries.List_Domain_Example;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class ValuesController : BaseController
    {
        private readonly IMapper _mapper;
        public ValuesController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// List Object
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// GET GetAll
        /// </remarks>
        /// <returns>Returns List_Domain</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User не авторизован</response>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List_Domain_Example.List_View_Model>> GetAll()
        {
            var query = new List_Domain_Example.Query
            {

            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost("create")]
     
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] Creat_Domain_ExampleDTO create_ProviderDto)
        {
            var command = _mapper.Map<Creat_Exemple.Command>(create_ProviderDto);
            var Id = await Mediator.Send(command);
            return Ok(Id);
        }
    }
}
