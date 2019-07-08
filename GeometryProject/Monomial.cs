using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryProject
{
    public class Monomial : IComparable<Monomial>
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

    }
}
