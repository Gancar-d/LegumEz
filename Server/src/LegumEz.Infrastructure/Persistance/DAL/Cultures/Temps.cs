using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegumEz.Infrastructure.Persistance.DAL.Cultures
{
    public enum UniteDeTemps
    {
        Jours,
        Semaines,
        Mois
    }

    public record Temps
    {
        public int Valeur { get; set; }
        public UniteDeTemps Unite { get; set; }
    }
}
