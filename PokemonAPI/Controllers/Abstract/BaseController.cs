using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace PokemonAPI.Controllers.Abstract
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator
        {
            get
            {
                if (_mediator != null)
                    return _mediator;
                _mediator = HttpContext?.RequestServices?.GetService<IMediator>();
                return _mediator;
            }
        }
    }
}
