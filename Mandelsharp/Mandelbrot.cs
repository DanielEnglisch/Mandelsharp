using System;

namespace Mandelsharp
{
    public class Mandelbrot
    {
      public static byte[] Generate(decimal dx, decimal dy, int iterations, decimal zoom, int size)
        {
            byte[] data = new byte[size * size * 3];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    int index = (y * size + x)*3;

                  
                    Complex c = new Complex(    ((decimal)(x - (size / 2)) / (decimal)(size / zoom)) + dx,
                                                ((decimal)(y - (size / 2)) / (decimal)(size / zoom)) + dy);
                    Complex z = new Complex(0, 0);

                    int it = 0;
                    do
                    {
                        it++;
                        z.Square();
                        z.Add(c);
                        if (z.Magnitude() > (decimal)2.0)
                            break;
                    } while (it < iterations);

                   
                        data[index + 0] = (byte)(it % 255);
                        data[index + 1] = (byte)(it % 255);
                        data[index + 2] = (byte)(it % 255);

                  //  Console.WriteLine(it);


                }

               Console.WriteLine("Column " + x + "/" + size);
            }


            return data;
        }
    }
}
