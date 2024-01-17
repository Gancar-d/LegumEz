using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegumEz.Domain.Entity
{
    public class Localisation
    {
        public string Ville { get; }
        public string Pays { get; }

        public Localisation(string ville, string pays)
        {
            if (string.IsNullOrEmpty(ville))
            {
                throw new ArgumentException("La ville doit être renseignée", nameof(ville));
            }

            if (string.IsNullOrEmpty(pays))
            {
                throw new ArgumentException("Le pays doit être renseigné", nameof(pays));
            }

            Ville = ville;
            Pays = pays;
        }
    }
}
