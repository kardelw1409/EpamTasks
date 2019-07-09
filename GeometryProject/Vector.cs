using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryProject
{
    public class Vector : IEquatable<Vector>
    {
        private readonly double coordinateX;
        private readonly double coordinateY;
        private readonly double coordinateZ;

        public Vector(double coordinateX, double coordinateY, double coordinateZ)
        {
            this.coordinateX = coordinateX;
            this.coordinateY = coordinateY;
            this.coordinateZ = coordinateZ;
        }

        public static Vector operator + (Vector firstVector, Vector secondVector)
        {
            return new Vector(firstVector.coordinateX + secondVector.coordinateX,
                firstVector.coordinateY + secondVector.coordinateY,
                firstVector.coordinateZ + secondVector.coordinateZ);
        }

        public static Vector operator - (Vector firstVector, Vector secondVector)
        {
            return new Vector(firstVector.coordinateX - secondVector.coordinateX,
                firstVector.coordinateY - secondVector.coordinateY,
                firstVector.coordinateZ - secondVector.coordinateZ);
        }

        public static Vector operator * (Vector vector, double number)
        {
            return new Vector(vector.coordinateX * number,
                vector.coordinateY * number,
                vector.coordinateZ * number);
        }

        public static Vector operator * (double number, Vector vector)
        {
            return vector * number;
        }

        public static double operator * (Vector firstVector, Vector secondVector)
        {
            return firstVector.coordinateX * secondVector.coordinateX +
                firstVector.coordinateY * secondVector.coordinateY +
                firstVector.coordinateZ * secondVector.coordinateZ;
        }

        public static Vector operator / (Vector vector, double number)
        {
            if (number == 0)
            {
                throw new ArithmeticException("Division by zero is impossible.");
            }
            return new Vector(vector.coordinateX / number,
                vector.coordinateY / number,
                vector.coordinateZ / number);
        }

        private double GetModule()
        {
            return Math.Sqrt(coordinateX * coordinateX + coordinateY * coordinateY +
                coordinateZ * coordinateZ);
        }

        public static double GetAngleBetweenVectors(Vector firstVector, Vector secondVector)
        {
            return Math.Acos((firstVector * secondVector) / (firstVector.GetModule() * 
                secondVector.GetModule()));
        }

        public override string ToString()
        {
            return "(" + coordinateX + ", " + coordinateY + ", "+ coordinateX + ")";
        }

        public bool Equals(Vector vector)
        {
            if (ReferenceEquals(null, vector))
            {
                return false;
            }
            if (ReferenceEquals(this, vector))
            {
                return true;
            }

            return coordinateX == vector.coordinateX && coordinateY == vector.coordinateY && coordinateZ == vector.coordinateZ;
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

            return obj.GetType() == GetType() && Equals((Vector)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 629017986;
            hashCode = hashCode * -1521134295 + coordinateX.GetHashCode();
            hashCode = hashCode * -1521134295 + coordinateY.GetHashCode();
            hashCode = hashCode * -1521134295 + coordinateZ.GetHashCode();
            return hashCode;
        }
    }
}
