using CommonAPI.Exceptions;
using CommonAPI.Interfaces.Services;
using CommonAPI.Models;
using MediatR;
using PokemonAPI.Application.Pokemon.Queries;
using PokemonAPI.Application.Services.Enums;
using PokemonAPI.Application.Services.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonAPI.Application.Translated.Queries
{
    public class GetTranslatedDetailsQueryHandler : BaseDetailsRequestHandler<
        GetTranslatedDetailsQuery,
        GetTranslatedDetailsFormRequest,
        GetTranslatedDetailsFormResponse,
        GetPokemonDetailsViewModel>
    {
        private const string HABITAT = "cave";

        private IMediator _mediator;
        private readonly IFuntranslationsApiClient<Services.Models.Pokemon> _funtranslationsApiClient;

        public GetTranslatedDetailsQueryHandler(
            IMediator mediator,
            IFuntranslationsApiClient<Services.Models.Pokemon> funtranslationsApiClient)
        {
            _mediator = mediator;
            _funtranslationsApiClient = funtranslationsApiClient;
        }

        protected override async Task<GetTranslatedDetailsFormResponse> BuildBaseResponseData(GetTranslatedDetailsFormRequest request, CancellationToken cancellationToken)
        {
            var pokemon = await _mediator.Send(new GetPokemonDetailsQuery(new GetPokemonDetailsFormRequest { Id = request.Id, Name = request.Name }));

            if (!pokemon.IsSuccess)
                throw new ApplicationException(pokemon.Error.Message);

            return new GetTranslatedDetailsFormResponse { Form = pokemon.Data.Form };
        }

        protected override async Task<GetTranslatedDetailsFormResponse> AdditionalLogic(GetTranslatedDetailsQuery requestQuery, GetTranslatedDetailsFormResponse response, CancellationToken cancellationToken)
        {
            try
            {
                if (response.Form.Habitat.ToLower().Trim() == HABITAT.ToLower().Trim()
                   || response.Form.IsLegendary)
                {
                    var trResponse = await _funtranslationsApiClient.PostTranslated<TranslatedResponse>((int)FuntranslationsEnum.Yoda,
                         response.Form.Description, cancellationToken);
                    if (trResponse.Success.Total >= 1)
                    {
                        response.Form.Description = trResponse.Contents.Translated;
                    }

                }
                else
                {
                    var trResponse = await _funtranslationsApiClient.PostTranslated<TranslatedResponse>((int)FuntranslationsEnum.Shakespeare,
                                         response.Form.Description, cancellationToken);
                    if (trResponse.Success.Total >= 1)
                    {
                        response.Form.Description = trResponse.Contents.Translated;
                    }
                }
            }catch(BaseException){ }
            return response;
        }
    }
}
