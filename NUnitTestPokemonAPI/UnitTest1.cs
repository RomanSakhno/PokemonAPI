using CommonAPI.Exceptions;
using FluentValidation.TestHelper;
using Newtonsoft.Json;
using NUnit.Framework;
using PokemonAPI.Application.Pokemon.Queries;
using PokemonAPI.Application.Services;
using PokemonAPI.Application.Services.Enums;
using PokemonAPI.Application.Services.Models;
using PokemonAPI.Application.Translated.Queries;
using PokemonAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NUnitTestPokemonAPI
{
    public class Tests
    {
        private TranslatedApiClient translatedApiClient;
        private PokemonApiClient pokemonApiClient;
        private GetPokemonDetailsQueryHandler getPokemonDetailsQueryHandler;
        private GetPokemonDetailsFormRequestValidator pokemonValidator;
        private GetTranslatedDetailsFormRequestValidator translatedValidator;

        [SetUp]
        public void Setup()
        {
            translatedApiClient = new TranslatedApiClient(
                "https://api.funtranslations.com/translate",
                new Dictionary<FuntranslationsEnum, string>
                {
                    [FuntranslationsEnum.Yoda] = "yoda",
                    [FuntranslationsEnum.Shakespeare] = "shakespeare"
                });

            pokemonApiClient = new PokemonApiClient(
                "https://pokeapi.co/api/v2/",
                new Dictionary<PokemonsEnum, string>
                {
                    [PokemonsEnum.PokemonSpecies] = "pokemon-species"
                });

            getPokemonDetailsQueryHandler = new GetPokemonDetailsQueryHandler(pokemonApiClient);
            pokemonValidator = new GetPokemonDetailsFormRequestValidator();
            translatedValidator = new GetTranslatedDetailsFormRequestValidator();
        }

        #region Validation Trests

        [Test]
        public void PokemonValidatorWhenBothParamIsNullOrEmpty()
        {
            var result = pokemonValidator.TestValidate(new GetPokemonDetailsFormRequest());
            result.ShouldHaveValidationErrorFor(r => new { r.Id, r.Name });
        }

        [Test]
        public void PokemonValidatorNameMaximumLength()
        {
            var result = pokemonValidator.TestValidate(new GetPokemonDetailsFormRequest { Name = new string('c', 51) });
            result.ShouldHaveValidationErrorFor(r => r.Name);
        }

        [Test]
        public void PokemonValidatorIdGreaterThan()
        {
            var result = pokemonValidator.TestValidate(new GetPokemonDetailsFormRequest { Id = -1 });
            result.ShouldHaveValidationErrorFor(r => r.Id);
        }

        [Test]
        public void TranslatedValidatorWhenBothParamIsNullOrEmpty()
        {
            var result = translatedValidator.TestValidate(new GetTranslatedDetailsFormRequest());
            result.ShouldHaveValidationErrorFor(r => new { r.Id, r.Name });
        }

        [Test]
        public void TranslatedValidatorNameMaximumLength()
        {
            var result = translatedValidator.TestValidate(new GetTranslatedDetailsFormRequest { Name = new string('c', 51) });
            result.ShouldHaveValidationErrorFor(r => r.Name);
        }

        [Test]
        public void TranslatedValidatorIdGreaterThan()
        {
            var result = translatedValidator.TestValidate(new GetTranslatedDetailsFormRequest { Id = -1 });
            result.ShouldHaveValidationErrorFor(r => r.Id);
        }
        #endregion

        [Test]
        public async Task PokemonGetDetailsHandler()
        {
            var result = await getPokemonDetailsQueryHandler.Handle(
                new GetPokemonDetailsQuery(new GetPokemonDetailsFormRequest
                {
                    Id = 150,
                    Name = "mewtwo"
                }), CancellationToken.None);

            Console.WriteLine(JsonConvert.SerializeObject(result));
            Assert.Pass();
        }

        [Test]
        public async Task PokemonApiSpekByName()
        {
            var result = await pokemonApiClient.GetPokemonSpeciesAsync<PokemonSpecies>("mewtwo", CancellationToken.None);
            Assert.AreEqual(result.Id, 150);
        }

        [Test]
        public async Task PokemonApiSpekById()
        {
            var result = await pokemonApiClient.GetPokemonSpeciesAsync<PokemonSpecies>("150", CancellationToken.None);
            Assert.AreEqual(result.Name, "mewtwo");
        }

        [Test]
        public void TranslatedApi()
        {
            Assert.ThrowsAsync(typeof(BaseException), async () =>
            {
                var result = await translatedApiClient.PostTranslated<TranslatedResponse>(
                (int)FuntranslationsEnum.Yoda,
                "It was created by\na scientist after\nyears of horrific\fgene splicing and\nDNA engineering\nexperiments.",
                CancellationToken.None);
            }, "Code 429");
        }
    }
}