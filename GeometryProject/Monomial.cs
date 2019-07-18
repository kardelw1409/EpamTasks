using System;

namespace GeometryProject
{
    public class Monomial : IComparable<Monomial>, IEquatable<Monomial>
    {
        public int Degree { get; private set; }
        public double Coefficient { get; private set; }

        public Monomial(int degree, double coefficient)
        {
            if (degree < 0)
            {
                throw new ArgumentException("Degree can't be negative!");
            }
            Degree = degree;
            Coefficient = coefficient;
        }

        public static Monomial operator / (Monomial monomialFirst, Monomial monomialSecond)
        {
            return new Monomial(monomialFirst.Degree - monomialSecond.Degree, monomialFirst.Coefficient / monomialSecond.Coefficient);
        }

        public int CompareTo(Monomial monomial)
        {
            return Degree.CompareTo(monomial.Degree);
        }

        public override string ToString()
        {
            return Coefficient == 0 ? "" : Coefficient.ToString("+#.##;-#.##") + "*" + "x" + "^" + Degree;
        }

        public bool Equals(Monomial monomial)
        {
            if (ReferenceEquals(null, monomial))
            {
                return false;
            }
            if (ReferenceEquals(this, monomial))
            {
                return true;
            }
            if (Degree != monomial.Degree)
            {
                return false;
            }
            return Coefficient == monomial.Coefficient && Degree == monomial.Degree;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return GetType() == obj.GetType() && Equals((Monomial)obj);
        }

        public static bool operator == (Monomial first, Monomial second)
        {
            return first.Equals(second);
        }
        public static bool operator != (Monomial first, Monomial second)
        {
            return !first.Equals(second);
        }

        public override int GetHashCode()
        {
            var hashCode = -1647794589;
            hashCode = hashCode * -1521134295 + Degree.GetHashCode();
            hashCode = hashCode * -1521134295 + Coefficient.GetHashCode();
            return hashCode;
        }
    }
}
