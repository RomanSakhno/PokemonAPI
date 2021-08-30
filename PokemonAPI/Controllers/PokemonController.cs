using CommonAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.App;
using PokemonAPI.Application.Pokemon.Queries;
using PokemonAPI.Application.Translated.Queries;
using PokemonAPI.Controllers.Abstract;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : BaseController
    {
        [AllowAnonymous]
        [HttpGet("{name}")]
        [ProducesResponseType(typeof(ResponseWrapper<GetPokemonDetailsFormResponse>), (int)HttpStatusCode.OK)]
        [Obsolete("Please use Details (details is supporting validation)")]
        public async Task<ActionResult<ResponseWrapper<GetPokemonDetailsFormResponse>>> Index(string name)
        {
            return Ok(await Mediator.Send(new GetPokemonDetailsQuery(new GetPokemonDetailsFormRequest { Name = name })));
        }
        
        [AllowAnonymous]
        [HttpGet("Index")]
        [ProducesResponseType(typeof(ResponseWrapper<GetPokemonDetailsFormResponse>), (int)HttpStatusCode.OK)]
        [Obsolete("Please use Details (details is supporting validation)")]
        public async Task<ActionResult<ResponseWrapper<GetPokemonDetailsFormResponse>>> Index([FromQuery] int? id)
        {
            return Ok(await Mediator.Send(new GetPokemonDetailsQuery(new GetPokemonDetailsFormRequest { Id = id })));
        }

        [AllowAnonymous]
        [HttpGet("Translated/{name}")]
        [ProducesResponseType(typeof(ResponseWrapper<GetTranslatedDetailsFormResponse>), (int)HttpStatusCode.OK)]
        [Obsolete("Please use TranslatedController.Details (details is supporting validation)")]
        public async Task<ActionResult<ResponseWrapper<GetTranslatedDetailsFormResponse>>> Translated(string name)
        {
            return Ok(await Mediator.Send(new GetTranslatedDetailsQuery(new GetTranslatedDetailsFormRequest { Name = name })));
        }

        [AllowAnonymous]
        [HttpGet("Details")]
        [ProducesResponseType(typeof(ResponseWrapper<GetPokemonDetailsFormResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseWrapper<GetPokemonDetailsFormResponse>>> Details([FromQuery] GetPokemonDetailsFormRequest request)
        {
            return Ok(await Mediator.Send(new GetPokemonDetailsQuery(request)));
        }
    }
}
