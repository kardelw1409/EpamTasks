using System;

namespace GeometryProject
{
    public class Triangle
    {
        public const string CannotCreateATriangleMessage = "Cannot create a triangle";
        public const string ValueNeedsToBePositive = "Value needs to be positive";

        private readonly double firstSide;
        private readonly double secondSide;
        private readonly double thridSide;

        public Triangle(double firstSide, double secondSide, double thridSide)
        {
            if ((firstSide < 0) || (secondSide < 0) || (thridSide < 0))
            {
                throw new ArgumentException(ValueNeedsToBePositive);
            }
            if ((firstSide + secondSide) <= thridSide || (firstSide + thridSide) <= secondSide
                || (thridSide + secondSide) <= firstSide)
            {
                throw new Exception(CannotCreateATriangleMessage);
            }
            this.firstSide = firstSide;
            this.secondSide = secondSide;
            this.thridSide = thridSide;
        }

        public double GetArea()
        {
            var semiPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - firstSide) * 
                (semiPerimeter - secondSide) * (semiPerimeter - thridSide));
        }

        public double GetPerimeter()
        {
            return firstSide + secondSide + thridSide;
        }
    }
}
