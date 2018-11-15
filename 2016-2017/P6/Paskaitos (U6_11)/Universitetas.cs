using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Universitetas
{
    const int CMax = 100;
    Studentas[] A;
    int n;

    public Universitetas() {
        A = new Studentas[CMax];
        n = 0;
    }

    public void Set(Studentas obj) { A[n++] = obj; }
    public int get() { return n; }
    public Studentas get(int i) { return A[i]; }
    public void Sort() {
        for (int j = 0; j < n; j++) {
            Studentas min = A[j];
            int min_i = j;

            for (int i = j + 1; i < n; i++) {
                if (A[i] <= min) {
                    min = A[i];
                    min_i = i;
                }
            }

            A[min_i] = A[j];
            A[j] = min;
        }
    }
    public int nonAbsentDaysCount() {
        int count = 0;

        for (int j = 0; j < A[0].getAbsentDaysArrayLength(); j++) {
            bool absent = false;

            for (int i = 0; i < n; i++)
                if (A[i].getAbsentDays(j) != 0)
                    absent = true;

            if (!absent)
                count++;
        }

        return count;
    }
    public int[] nonAbsentDays() {
        int[] a = new int[nonAbsentDaysCount()];
        int pos = 0;

        for (int j = 0; j < A[0].getAbsentDaysArrayLength(); j++) {
            bool absent = false;

            for (int i = 0; i < n; i++)
                if (A[i].getAbsentDays(j) != 0)
                    absent = true;

            if (!absent)
                a[pos++] = j;
        }

        return a;
    }
    public int DifferentProffesionsCount() {
        string[] professions = new string[CMax];
        int p = 0;

        for (int j = 0; j < n; j++) {
            bool isAlreadyCounted = false;
            for (int i = 0; i < p; i++)
                if (A[j].getProfession() == professions[i])
                    isAlreadyCounted = true;

            if (!isAlreadyCounted)
                professions[p++] = A[j].getProfession();
        }

        return p;
    }
    public string[] DifferentProfessions() {
        string[] professions = new string[DifferentProffesionsCount()];
        int p = 0;

        for (int j = 0; j < n; j++) {
            bool isAlreadyCounted = false;

            for (int i = 0; i < p; i++)
                if (professions[i] == A[j].getProfession())
                    isAlreadyCounted = true;

            if (!isAlreadyCounted)
                professions[p++] = A[j].getProfession();
        }

        return professions;
    }
    public int[] DifferentProfessionsAbsentHours() {
        int[] hours = new int[DifferentProffesionsCount()];
        string[] professions = DifferentProfessions();

        for (int h = 0; h < hours.Length; h++) {
            for (int j = 0; j < n; j++) {
                if (professions[h] == A[j].getProfession())
                    hours[h] += A[j].getAbsentHours();
            }
        }

        return hours;
    }
    public int StudentsWhoShouldBeRemovedCount() {
        int count = 0;

        for (int i = 0; i < n; i++)
            if (A[i].ShouldBeRemoved())
                count++;

        return count;
    }
    public int[] StudentsWhoShouldBeRemovedIndexes() {
        int count = StudentsWhoShouldBeRemovedCount();

        if (count == 0)
            return new int[0];

        int[] indexes = new int[count];
        int s = 0;

        for (int i = 0; i < n; i++)
            if (A[i].ShouldBeRemoved())
                indexes[s++] = i;

        return indexes;
    }
    public void Remove(int[] indexes) {
        for (int j = 0; j < indexes.Length; j++) {
            for (int i = indexes[j]; i < n - 1; i++) {
                A[i] = A[i + 1];
            }
            n--;
        }
    }
    public void WriteStudentsToConsole()
    {
        string viršus =
            "-----------------------------------------\n\r" +
            "   Pavardė  Vardas Fakultetas Specialybė \n\r" +
            "-----------------------------------------";

        if (n != 0) {
            Console.WriteLine(viršus);
            for (int i = 0; i < n; i++) {
                Console.WriteLine(A[i].ToString());
            }
        }
        else
            Console.WriteLine("Sąrašas tuščias!");
    }
    public void WriteAbsentDaysToConsole() {
        string viršus = "   ";
        for (int i = 0; i < A[0].getAbsentDaysArrayLength(); i++) {
            if (i != A[0].getAbsentDaysArrayLength() - 1)
                viršus += (i + 1) + " ";
            else
                viršus += (i + 1);
        }

        Console.WriteLine(viršus);
        for (int i = 0; i < n; i++) {
            Console.WriteLine("{0}. {1}", i + 1, A[i].AbsentDaysToString());
        }
    }
    public void WriteNonAbsentDaysToConsole(int[] days) {
        string output = "";

        for (int i = 0; i < days.Length; i++) {
            if (i != days.Length - 1)
                output += (days[i] + 1) + ", ";
            else
                output += (days[i] + 1);
        }

        if (output != "")
            Console.WriteLine("Dienos, per kurias nebuvo praleistos paskaitos: " + output);
        else
            Console.WriteLine("Dienų, per kurias nebūtų praleista paskaitų, nebuvo");
    }
    public void WriteDifferentProfessionsAbsentHours() {
        string[] professions = DifferentProfessions();
        int[] hours = DifferentProfessionsAbsentHours();

        Console.WriteLine("Skirtingų profesijų praleistų valandų kiekis:");
        for (int i = 0; i < professions.Length; i++) {
            Console.WriteLine("{0}: {1}", professions[i], hours[i]);
        }
    }
}
