﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegumEz.Application.Cultures
{
    public record CultureDto
    {
        public CultureDto(Guid id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public Guid Id { get; }
        public string Nom { get; }
    }
}
