using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryProject
{
    public class Monomial //: IComparable
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

        public override string ToString()
        {
            return Coefficient == 0 ? "" : Coefficient.ToString("+#.##;-#.##") + "*" + "x" + "^" + Degree;
        }

        /*private int IComparer.Compare(object monomialFirst, object monomialSecond)
        {
            if (((Monomial)monomialFirst).Degree > ((Monomial)monomialSecond).Degree)
            {
                return 1;
            }
            if (((Monomial)monomialFirst).Degree == ((Monomial)monomialSecond).Degree)
            {
                return 0;
            }
            if (((Monomial)monomialFirst).Degree  ((Monomial)monomialSecond).Degree)
            {
                return -1;
            }
        }*/
    }
}
