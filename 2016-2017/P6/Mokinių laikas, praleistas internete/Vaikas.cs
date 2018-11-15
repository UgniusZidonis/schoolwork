using System;

internal class Vaikas
{
    private string name, surname;
    private int grade;
    private double average;
    private int[] timeOnNet;
    private int allTimeOnNet;

    public Vaikas(string name, string surname, int grade, double average)
    {
        this.name = name;
        this.surname = surname;
        this.grade = grade;
        this.average = average;
        allTimeOnNet = 0;
    }

    public string getName() { return name; }
    public string getSurname() { return surname; }
    public int getGrade() { return grade; }
    public double getAverage() { return average; }
    public int[] getTimeOnNet() { return timeOnNet; }
    public int getAllTimeOnNet() { return allTimeOnNet; }

    public void setTimeOnNet(int[] times) {
        timeOnNet = times;

        for (int i = 0; i < timeOnNet.Length; i++)
            allTimeOnNet += timeOnNet[i];
    }
    public override string ToString() { return String.Format("{0,-11} {1,-8} {2,6} {3,13:f2}", surname, name, grade, allTimeOnNet); }
    public string TimeArrayToString() {
        string output = "";

        for (int i = 0; i < timeOnNet.Length; i++) {
            if (i != timeOnNet.Length - 1)
                output += String.Format("{0,3:d} ", timeOnNet[i]);
            else
                output += String.Format("{0,3:d}", timeOnNet[i]);
        }

        return output;
    }

    public static bool operator <=(Vaikas v1, Vaikas v2)
    {
        int k;
        if (v1.grade < v2.grade) k = -1; else if (v1.grade == v2.grade) k = 0; else k = 1;
        int t;
        if (v1.allTimeOnNet < v2.allTimeOnNet) t = -1; else if (v1.timeOnNet == v2.timeOnNet) t = 0; else t = 1;
        int v = String.Compare(v1.surname, v2.surname);

        return k < 0 || (k == 0 && t < 0) || (k == 0 && t == 0 && v < 0);
    }

    public static bool operator >=(Vaikas v1, Vaikas v2)
    {
        int k;
        if (v1.grade < v2.grade) k = -1; else if (v1.grade == v2.grade) k = 0; else k = 1;
        int t;
        if (v1.allTimeOnNet < v2.allTimeOnNet) t = -1; else if (v1.timeOnNet == v2.timeOnNet) t = 0; else t = 1;

        return k > 0 || (k == 0 && t > 0);
    }
}