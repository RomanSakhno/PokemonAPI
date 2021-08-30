using System;

namespace PokemonAPI.App
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FromJsonQueryAttribute : Attribute
    {
        public string Name { get; set; } = "request";
    }
}
