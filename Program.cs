using System;

namespace DistanceMatrix
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            double[,] testmatrix1 = rastgeleNokta(100, 100, 10);

            double[,] testmatrix2 = rastgeleNokta(100, 100, 100);

            /*RASTGELE NOKTALAR YAZDIRMA KISMI*/
            Console.WriteLine("RASTGELE NOKTALAR 1 (Width: 100, Height: 100, n: 10)\n");
            for (int i = 0; i < testmatrix1.GetLength(0); i++)
            {
                Console.Write("X koordinatı: {0:0.00}", testmatrix1[i, 0]);
                Console.WriteLine("\tY koordinatı: {0:0.00}", testmatrix1[i, 1]);
            }

            Console.WriteLine("\nRASTGELE NOKTALAR 2 (Width: 100, Height: 100, n:100)\n");
            for (int i = 0; i < testmatrix2.GetLength(0); i++)
            {
                Console.Write("X koordinatı: {0:0.00}", testmatrix2[i, 0]);
                Console.WriteLine("\tY koordinatı: {0:0.00}", testmatrix2[i, 1]);
            }

            /*UZAKLIK MATRİSİ YAZDIRMA KISMI*/
            Console.WriteLine("\nUZAKLIK MATRİSİ (Width: 100, Height: 100, n:10)\n");
            Console.WriteLine("       0    1     2     3     4     5     6     7     8     9");
            Console.WriteLine("      ---  ---   ---   ---   ---   ---   ---   ---   ---   ---  ");
            for (int i = 0; i < testmatrix1.GetLength(0); i++) // Örnekte aynı değerler verildiğinden burda da testmatrisi1'i kullanıyorum
            {

                Console.Write(i + " | ");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(" {0:0.00}", uzaklikMatrisi(testmatrix1)[i, j]);
                }
                Console.WriteLine();
            }


            Console.ReadKey();
        }

        static double[,] rastgeleNokta(int width, int height, int n)
        {
            double[,] noktalar = new double[n, 2];
            for (int i = 0; i < n; i++)
            {
                double coordinate_x = random.NextDouble() * width; //random.NextDouble() metodu 0 ile 1 arasında bir değer döndürüyor bunu widthle çarparak 0 ile width arasında bir double değer elde ediyorum 
                double coordinate_y = random.NextDouble() * height;
                noktalar[i, 0] = coordinate_x;
                noktalar[i, 1] = coordinate_y;
            }
            return noktalar;
        }

        static double[,] uzaklikMatrisi(double[,] noktalarMatrisi)
        {
            double[,] uzakliklar = new double[noktalarMatrisi.GetLength(0), noktalarMatrisi.GetLength(0)]; //nokta sayısıxnokta sayısı şeklinde matris.
            for (int i = 0; i < noktalarMatrisi.GetLength(0); i++) //üstteki matris için sırayla satırlara giriş.
            {
                for (int j = 0; j < noktalarMatrisi.GetLength(0); j++) //girilen satırın sütunlarını doldurma.
                {
                    uzakliklar[i, j] = Math.Sqrt(Math.Pow(noktalarMatrisi[i, 0] - noktalarMatrisi[j, 0], 2) +
                        Math.Pow(noktalarMatrisi[i, 1] - noktalarMatrisi[j, 1], 2));
                    //Üstteki iki nokta arası uzaklık hesaplama formülü.
                }

            }
            return uzakliklar;
        }
    }
}
