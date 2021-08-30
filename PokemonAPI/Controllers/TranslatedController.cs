using CommonAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.App;
using PokemonAPI.Application.Translated.Queries;
using PokemonAPI.Controllers.Abstract;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslatedController : BaseController
    {
        [AllowAnonymous]
        [HttpGet("{name}")]
        [ProducesResponseType(typeof(ResponseWrapper<GetTranslatedDetailsFormResponse>), (int)HttpStatusCode.OK)]
        [Obsolete("Please use Details (details is supporting validation)")]
        public async Task<ActionResult<ResponseWrapper<GetTranslatedDetailsFormResponse>>> Index(string name)
        {
            return Ok(await Mediator.Send(new GetTranslatedDetailsQuery(new GetTranslatedDetailsFormRequest { Name = name })));
        }

        [AllowAnonymous]
        [HttpGet("Index")]
        [ProducesResponseType(typeof(ResponseWrapper<GetTranslatedDetailsFormResponse>), (int)HttpStatusCode.OK)]
        [Obsolete("Please use Details (details is supporting validation)")]
        public async Task<ActionResult<ResponseWrapper<GetTranslatedDetailsFormResponse>>> Index([FromQuery] int? id)
        {
            return Ok(await Mediator.Send(new GetTranslatedDetailsQuery(new GetTranslatedDetailsFormRequest { Id = id })));
        }

        [AllowAnonymous]
        [HttpGet("Details")]
        [ProducesResponseType(typeof(ResponseWrapper<GetTranslatedDetailsFormResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseWrapper<GetTranslatedDetailsFormResponse>>> Details([FromQuery] GetTranslatedDetailsFormRequest request)
        {
            return Ok(await Mediator.Send(new GetTranslatedDetailsQuery(request)));
        }
    }
}
