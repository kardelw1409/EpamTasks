using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryProject
{
    public class Monomial
    {
        public int Degree { get; private set; }
        public double Coefficient { get; private set; }

        public Monomial(int degree, double coefficient)
        {
            Degree = degree;
            Coefficient = coefficient;
        }

        public override string ToString()
        {
            return Coefficient == 0 ? "" : Coefficient.ToString("+#.##;-#.##") + "*" + "x" + "^" + Degree;
        }
    }
}
