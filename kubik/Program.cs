using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] x;
            float[] y;
            float[] a;
            float[] Xcari;
            float Ycari=0;
            float[,] matriks;

            Console.Write("banyak titik : ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n > 2)
            {
                x = new float[n];
                y = new float[n];
                a = new float[n];
                matriks = new float[n, n];
                for (int i = 0; i < n; i++)
                {
                    Console.Write("X{0} : ", i + 1);
                    x[i] = Convert.ToSingle(Console.ReadLine());
                    for (int j = 0; j < n; j++)
                    {
                        matriks[i, j] = pangkat(x[i], j);
                    }

                    Console.Write("Y{0} : ", i + 1);
                    y[i] = Convert.ToSingle(Console.ReadLine());
                }
                a = Eliminasi_Gaus_Jordan_Naif(matriks, y, n);

                Xcari = new float[n];
                Console.Write("nilai y yang di cari pada x : ");
                Xcari[1]= Convert.ToSingle(Console.ReadLine());
                
                for (int j = 0; j < n; j++)
                {
                    Xcari[j] = pangkat(Xcari[1], j);
                    Ycari = Ycari + a[j] * Xcari[j];
                }
                Console.WriteLine("{0,5}", Ycari);
                Console.ReadKey();
            }
            else
            {
                Console.Write("Banyak titik harus lebih besar dari 2");
                Console.ReadKey();
            }
        }

        static float pangkat(float X, int tingkat)
        {
            float hasil=1;
            if (tingkat > 0)
            {
                for (int i = 0; i < tingkat; i++)
                {
                    hasil = hasil * X;
                }
                return hasil;
            }
            else
            {
                return 1;
            }
        }

        static float[] Eliminasi_Gaus_Jordan_Naif(float[,] A, float[] b, int n)
        {
            float[] hasil = new float[n];
            float tampung,m;
            for (int k = 0; k < n; k++)
            {
                tampung = A[k,k];
                for (int j = 0; j < n; j++)
                {
                    A[k, j] = A[k, j] / tampung;
                }
                b[k] = b[k] / tampung;

                for (int i = 0; i < n; i++)
                {
                    if (i != k)
                    {
                        m = A[i, k];
                        for (int j = 0; j < n; j++)
                        {
                            A[i, j] = A[i, j] - m * A[k, j];
                        }
                        b[i] = b[i] - m * b[k];
                    }
                }
            }

            return b;
        }
    }
}
