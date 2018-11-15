using System;

internal class Studentas
{
    string name, surname;
    string faculty, profession;
    int[] absentDays;

    public Studentas(string surname, string name, string faculty, string profession, int absentDayCount)
    {
        this.surname = surname;
        this.name = name;
        this.faculty = faculty;
        this.profession = profession;
        absentDays = new int[absentDayCount];
    }

    public string getName() { return name; }
    public string getSurname() { return surname; }
    public string getFaculty() { return faculty; }
    public string getProfession() { return profession; }
    public int getAbsentDaysArrayLength() { return absentDays.Length; }
    public int getAbsentDays(int i) { return absentDays[i]; }

    public override string ToString() { return String.Format("{0,10} {1,7} {2,6} {3,10}", surname, name, faculty, profession); }
    public string AbsentDaysToString() {
        string output = "";

        for (int i = 0; i < absentDays.Length; i++) {
            if (i != absentDays.Length - 1)
                output += absentDays[i] + " ";
            else
                output += absentDays[i];
        }

        return output;
    }

    public void setAbsentDays(int[] absentDays) { this.absentDays = absentDays; }

    public static bool operator <=(Studentas s1, Studentas s2) {
        int s = String.Compare(s1.profession, s2.profession);
        int v = String.Compare(s1.surname, s2.surname);

        return s < 0 || (s == 0 && v < 0);
    }

    public static bool operator >=(Studentas s1, Studentas s2) {
        int s = String.Compare(s1.profession, s2.profession);
        int v = String.Compare(s1.surname, s2.surname);

        return s > 0 || (s == 0 && v > 0);
    }

    public int getAbsentHours() {
        int sum = 0;
        for (int i = 0; i < absentDays.Length; i++)
            sum += absentDays[i];

        return sum;
    }

    public bool ShouldBeRemoved() {
        int count = 0;

        for (int i = 0; i < absentDays.Length; i++) {
            if (absentDays[i] != 0)
                count++;
        }

        return count > (absentDays.Length / 2);
    }
}