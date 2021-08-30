using CommonAPI.Models;

namespace PokemonAPI.Application.Translated.Queries
{
    public class GetTranslatedDetailsQuery : BaseDetailsQuery<GetTranslatedDetailsFormRequest, GetTranslatedDetailsFormResponse>
    {
        public GetTranslatedDetailsQuery(GetTranslatedDetailsFormRequest request) : base(request)
        {
        }
    }
}
