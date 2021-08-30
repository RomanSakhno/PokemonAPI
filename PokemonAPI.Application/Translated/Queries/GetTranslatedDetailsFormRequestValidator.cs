using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAPI.Application.Translated.Queries
{
    public class GetTranslatedDetailsFormRequestValidator : AbstractValidator<GetTranslatedDetailsFormRequest>
    {
        public GetTranslatedDetailsFormRequestValidator()
        {
            RuleFor(m => new { m.Id, m.Name }).Must(x => x.Id.HasValue || !string.IsNullOrEmpty(x.Name)).WithMessage("'id' or 'name' must be have a value!");
            RuleFor(m => m.Name).MaximumLength(50);
            RuleFor(m => m.Id).GreaterThan(0);
        }
    }
}
