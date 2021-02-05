using System;
using System.Collections.Generic;
using System.Linq;

namespace Class
{
    public class Rectangle
    {
        private double sideA;
        private double sideB;

        public Rectangle(double a, double b)
        {
            sideA = a;
            sideB = b;
        }

        public Rectangle(double a)
        {
            sideA = a;
            sideB = 5;
        }

        public Rectangle()
        {
            sideA = 4;
            sideB = 3;
        }

        public double GetSideA()
        {
            return sideA;
        }

        public double GetSideB()
        {
            return sideB;
        }

        public double Area()
        {
            return sideA * sideB;
        }

        public double Perimeter()
        {
            return (sideA + sideB) * 2;
        }

        public bool IsSquare()
        {
            return sideA == sideB;
        }

        public void ReplaceSides()
        {
            var buffer = sideA;

            sideA = sideB;
            sideB = buffer;
        }
    }

    public class ArrayRectangles
    {
        private readonly Rectangle[] rectangle_array;

        public ArrayRectangles(int n)
        {
            rectangle_array = new Rectangle[n];
        }

        public ArrayRectangles(IEnumerable<Rectangle> array)
        {
            rectangle_array = (Rectangle[])array;
        }

        public bool AddRectangle(Rectangle rectangle)
        {
            var added = false;

            for (int i = 0; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] != default) continue;

                rectangle_array[i] = rectangle;
                added = true;
            }

            return added;
        }

        public int NumberMaxArea()
        {
            var rectangleWithMaxArea = rectangle_array.OrderByDescending(rec => rec?.Area()).FirstOrDefault();

            return Array.IndexOf(rectangle_array, rectangleWithMaxArea);
        }

        public int NumberMinPerimeter()
        {
            var rectangleWithMinPerimeter = rectangle_array.OrderBy(rec => rec?.Perimeter()).FirstOrDefault();

            return Array.IndexOf(rectangle_array, rectangleWithMinPerimeter);
        }

        public int NumberSquare()
        {
            return rectangle_array.Count(rec => rec?.IsSquare() == true);
        }
    }
}
