using System;

namespace LDS_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kiek rasti pirminių skaičių porų?");
            int findPairs = int.Parse(Console.ReadLine());
            int[,] primeNumberPairs = new int[findPairs, 2];
            FindPairs(findPairs, ref primeNumberPairs);
            WritePairs(primeNumberPairs);
        }
        static bool isPrime(int number) {
            if (number == 0 || number == 1) return false;
            if (number % 2 == 0) return false;

            for (int i = 3; i < number; i++)
                if (number % i == 0) return false;

            return true;
        }
        static void FindPair(int startingPoint, out int number1, out int number2) {
            bool found = false;
            number1 = -1;
            number2 = -1;

            if (startingPoint % 2 == 0)
                startingPoint++;

            while (!found && startingPoint < 2147483645) {
                if (isPrime(startingPoint)) {
                    if (isPrime(startingPoint + 2)) {
                        number1 = startingPoint;
                        number2 = startingPoint + 2;
                        found = true;
                    }
                }
                startingPoint += 2;
            }
        }
        static void FindPairs(int k, ref int[,] matrix) {
            for (int i = 0; i < k; i++) {
                if (i < 1)
                    FindPair(0, out matrix[0, 0], out matrix[0, 1]);
                else
                    FindPair(matrix[i - 1, 1], out matrix[i, 0], out matrix[i, 1]);
            }
        }
        static void WritePairs(int[,] primeNumberPairs) {
            for (int i = 0; i < primeNumberPairs.GetLongLength(0); i++) {
                Console.WriteLine("{0} {1}", primeNumberPairs[i, 0], primeNumberPairs[i, 1]);
            }
        }
    }
}
