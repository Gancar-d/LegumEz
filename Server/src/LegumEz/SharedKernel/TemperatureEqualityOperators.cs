namespace LegumEz.Domain.SharedKernel
{
    public partial record Temperature
    {
        public override int GetHashCode()
        {
            return HashCode.Combine(Valeur, Unite);
        }

        public static bool operator >(Temperature left, Temperature right)
        {
            if (left.Unite != right.Unite)
            {
                throw new InvalidOperationException("Les deux températures doivent être dans la même unité");
            }

            return left.Valeur > right.Valeur;
        }

        public static bool operator >=(Temperature left, Temperature right)
        {
            if (left.Unite != right.Unite)
            {
                throw new InvalidOperationException("Les deux températures doivent être dans la même unité");
            }

            return left.Valeur >= right.Valeur;
        }

        public static bool operator <(Temperature left, Temperature right)
        {
            if (left.Unite != right.Unite)
            {
                throw new InvalidOperationException("Les deux températures doivent être dans la même unité");
            }

            return left.Valeur < right.Valeur;
        }

        public static bool operator <=(Temperature left, Temperature right)
        {
            if (left.Unite != right.Unite)
            {
                throw new InvalidOperationException("Les deux températures doivent être dans la même unité");
            }

            return left.Valeur <= right.Valeur;
        }

        public static Temperature operator +(Temperature left, Temperature right)
        {
            if (left.Unite != right.Unite)
            {
                throw new InvalidOperationException("Les deux températures doivent être dans la même unité");
            }

            return new Temperature(left.Valeur + right.Valeur, left.Unite);
        }

        public static Temperature operator -(Temperature left, Temperature right)
        {
            if (left.Unite != right.Unite)
            {
                throw new InvalidOperationException("Les deux températures doivent être dans la même unité");
            }

            return new Temperature(left.Valeur - right.Valeur, left.Unite);
        }

        public static Temperature operator *(Temperature left, Temperature right)
        {
            if (left.Unite != right.Unite)
            {
                throw new InvalidOperationException("Les deux températures doivent être dans la même unité");
            }

            return new Temperature(left.Valeur * right.Valeur, left.Unite);
        }

        public static Temperature operator /(Temperature left, Temperature right)
        {
            if (left.Unite != right.Unite)
            {
                throw new InvalidOperationException("Les deux températures doivent être dans la même unité");
            }

            return new Temperature(left.Valeur / right.Valeur, left.Unite);
        }
    }
}
