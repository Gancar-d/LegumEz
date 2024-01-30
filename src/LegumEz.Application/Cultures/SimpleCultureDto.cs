using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegumEz.Application.Cultures
{
    public record SimpleCultureDto
    {
        public SimpleCultureDto(Guid id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public Guid Id { get; }
        public string Nom { get; }
    }
}
