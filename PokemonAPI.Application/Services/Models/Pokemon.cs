using CommonAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAPI.Application.Services.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Habitat { get; set; }
        public bool IsLegendaty { get; set; }
    }
}
