using CommonAPI.Exceptions;
using CommonAPI.Interfaces.Services;
using CommonAPI.Models;
using Newtonsoft.Json;
using PokemonAPI.Application.Services.Enums;
using PokemonAPI.Application.Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonAPI.Application.Services
{
    public class TranslatedApiClient : BaseApiClient, IFuntranslationsApiClient<Models.Pokemon>
    {
        private readonly Dictionary<FuntranslationsEnum, string> _methods;
        public TranslatedApiClient(string baseUri, Dictionary<FuntranslationsEnum, string> methods) : base(baseUri)
        {
            _methods = methods;
        }

        public async Task<TranslatedResponse> PostTranslated<TranslatedResponse>(int method, string body, CancellationToken cancelationToken)
        {
            return await base.PostAsync<TranslatedResponse>(
                _methods[(FuntranslationsEnum)method],
                JsonConvert.SerializeObject(new TranslatedRequest { Text = body }),
                cancelationToken);
        }
    }
}
