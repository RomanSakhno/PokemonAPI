using Microsoft.Extensions.DependencyInjection;
using CommonAPI.Behaviours;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using CommonAPI.Interfaces.Services;
using PokemonAPI.Application.Services;
using System.Collections.Generic;
using PokemonAPI.Application.Services.Enums;
using FluentValidation;
using PokemonAPI.Application.Pokemon.Queries;

namespace PokemonAPI.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ResponseWrapperBehavior<,>));

            services.AddScoped<IPokemonApiClient<Services.Models.Pokemon>, PokemonApiClient>(sp => {
                var aSettings = Configuration.GetSection("ApiSettings");
                var dictioanry = new Dictionary<PokemonsEnum, string>
                {
                    [PokemonsEnum.PokemonSpecies] = aSettings["PokemonPokemonSpeciesMethod"]
                };

                using (var scoup = sp.CreateScope())
                {
                    return new PokemonApiClient(aSettings["PokemonBaseUrl"], dictioanry);
                }
            });

            services.AddScoped<IFuntranslationsApiClient<Services.Models.Pokemon>, TranslatedApiClient>(sp => {
                
                var aSettings = Configuration.GetSection("ApiSettings");
                var dictioanry = new Dictionary<FuntranslationsEnum, string> { 
                    [FuntranslationsEnum.Yoda] = aSettings["FuntranslationsYodaMethod"],
                    [FuntranslationsEnum.Shakespeare] = aSettings["FuntranslationsShakespeareMethod"],
                };

                using (var scoup = sp.CreateScope())
                {
                    return new TranslatedApiClient(aSettings["Funtranslations"], dictioanry);
                }

            });

            return services;
        }
    }
}
