using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBox
{
    public static class TriangleMath
    {
        public static double GetRightTriangleSquare(double side1, double side2, double side3)
        {
            return GetTriangleSquare(side1, side2, side3);
        }
        public static double GetRightTriangleSquare(double cathetus1, double cathetus2)
        {
            if (cathetus1 <= 0 || cathetus2 <= 0)
            {
                throw new ArgumentException("Sides length must be positive.");
            }
            return cathetus1*cathetus2/2;
        }
        public static double GetTriangleSquare(double side1, double side2, double side3)
        {
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            {
                throw new ArgumentException("Sides length must be positive.");
            }
            if (side1 >= side2 + side3 || side2 >= side1 + side3 || side3 >= side1 + side2)
            {
                throw new ArgumentException("Every side must be less than sum of others.");
            }
            var p = (side1 + side2 + side3)/2;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3)); 
        }
    }
}
