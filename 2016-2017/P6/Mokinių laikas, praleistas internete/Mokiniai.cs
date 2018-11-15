using System;

internal class Mokiniai
{
    const int CMax = 100;
    private Vaikas[] A;
    private int n;

    public Mokiniai()
    {
        A = new Vaikas[CMax];
        n = 0;
    }

    public void set(Vaikas obj)
    {
        A[n++] = obj;
    }

    public Vaikas get(int i) { return A[i]; }
    public int get() { return n; }
    public int get(Vaikas obj) {
        for (int i = 0; i < n; i++)
            if (A[i] == obj)
                return i;
        return -1;
    }

    public void Sort()
    {

        for (int j = 0; j < n - 1; j++)
        {
            Vaikas min = A[j];
            int min_i = j;
            for (int i = j + 1; i < n; i++)
            {
                if (A[i] <= min)
                {
                    min = A[i];
                    min_i = i;
                }
            }

            A[min_i] = A[j];
            A[j] = min;
        }
    }

    public double getAverageTimeSpentOnNet(int grade) {
        double sum = 0;
        int count = 0;

        for (int i = 0; i < n; i++) {
            if (A[i].getGrade() == grade) {
                sum += A[i].getAllTimeOnNet();
                count++;
            }
        }

        return sum / (double)count;
    }

    public int getKidsNotUsingTheInternetCount() {
        int sum = 0;

        for (int i = 0; i < n; i++)
            if (A[i].getAllTimeOnNet() == 0)
                sum++;

        return sum;
    }

    public void WriteKidsToConsole() {
        string viršus =
                "----------------------------------------------\r\n" +
                "Nr. Pavardė     Vardas      Klasė      Laikas\r\n" +
                "----------------------------------------------";

        Console.WriteLine(viršus);
        for (int i = 0; i < n; i++) {
            Console.WriteLine(" {0}. {1}", i + 1, A[i].ToString());
        }
    }
    public void WriteTimesToConsole() {
        for (int i = 0; i < n; i++) {
            Console.WriteLine("{0}. {1}", i + 1, A[i].TimeArrayToString());
        }
    }
}