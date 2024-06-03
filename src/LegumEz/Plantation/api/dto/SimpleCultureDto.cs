using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegumEz.Domain.Plantation.api.dto
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
