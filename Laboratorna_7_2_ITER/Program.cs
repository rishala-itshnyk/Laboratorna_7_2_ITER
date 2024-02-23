using System;

namespace Laboratorna_7_2_ITER;

public class Program
{
    static void Main()
    {
        Random rand = new Random();

        int Low = 7;
        int High = 65;
        int k, n;

        Console.Write("k = ");
        k = int.Parse(Console.ReadLine());

        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());

        int[][] a = new int[k][];

        for (int i = 0; i < k; i++)
            a[i] = new int[n];

        Create(a, k, n, Low, High);
        Print(a, k, n);

        int minOfMax;

        if (SearchMinOfMax(a, k, n, out minOfMax))
            Console.WriteLine("min of max even = " + minOfMax);
        else
            Console.WriteLine("there are no even elements in even rows");

        for (int i = 0; i < k; i++)
            Array.Clear(a[i], 0, a[i].Length);

        Array.Clear(a, 0, a.Length);

    }

    public static void Create(int[][] a, int k, int n, int Low, int High)
    {
        Random rand = new Random();

        for (int i = 0; i < k; i++)
            for (int j = 0; j < n; j++)
                a[i][j] = Low + rand.Next(High - Low + 1);
    }

    public static void Print(int[][] a, int k, int n)
    {
        Console.WriteLine();

        for (int i = 0; i < k; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write($"{a[i][j],4}");

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public static bool SearchMinOfMax(int[][] a, int k, int n, out int minOfMax)
    {
        minOfMax = -1;

        for (int i = 1; i < k; i += 2)
        {
            int maxInRow = a[i][0];

            for (int j = 1; j < n; j++)
            {
                if (a[i][j] > maxInRow)
                {
                    maxInRow = a[i][j];
                }
            }

            if (minOfMax == -1 || maxInRow < minOfMax)
            {
                minOfMax = maxInRow;
            }
        }

        return minOfMax != -1;
    }
}
