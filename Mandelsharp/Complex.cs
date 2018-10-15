using System;
using System.Collections.Generic;
using System.Text;

namespace Mandelsharp
{
    public struct Complex
    {
        private decimal r;
        private decimal i;

        public Complex(decimal r, decimal i)
        {
            this.r = r;
            this.i = i;
        }

        public void Add(Complex c)
        {
            r += c.r;
            i += c.i;
        }

        public void Square()
        {
            decimal temp = (r * r) - (i * i);
            i = (decimal)(2.0)*r*i;
            r = temp;
        }

        public decimal Magnitude()
        {
            return (decimal)Math.Sqrt((double)(r * r) + (double)(i * i));
        }

        public static decimal Sqrt(decimal x, decimal epsilon = 0.0M)
        {
            if (x < 0) throw new OverflowException("Cannot calculate square root from a negative number");

            decimal current = (decimal)Math.Sqrt((double)x), previous;
            do
            {
                previous = current;
                if (previous == 0.0M) return 0;
                current = (previous + x / previous) / 2;
            }
            while (Math.Abs(previous - current) > epsilon);
            return current;
        }

    }
}
