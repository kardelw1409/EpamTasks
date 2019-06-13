using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryProject
{
    public class Vector
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

        public double GetModule()
        {
            return Math.Sqrt(coordinateX * coordinateX + coordinateY * coordinateY +
                coordinateZ * coordinateZ);
        }

        public static double operator * (Vector firstVector, Vector secondVector)
        {
            return firstVector.coordinateX * secondVector.coordinateX +
                firstVector.coordinateY * secondVector.coordinateY +
                firstVector.coordinateZ * secondVector.coordinateZ;
        }

        public static double GetAngleBetweenVectors(Vector firstVector, Vector secondVector)
        {
            return Math.Acos((firstVector * secondVector) / (firstVector.GetModule() * 
                secondVector.GetModule()));
        }
    }
}
