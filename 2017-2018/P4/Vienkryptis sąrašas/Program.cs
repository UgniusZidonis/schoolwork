using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4
{
    class Program
    {
        const string inputFile1 = "../../Darius.txt";
        const string inputFile2 = "../../Mikas.txt";
        const string outputFile = "../../output.txt";
        static void Main(string[] args) {
            if(File.Exists(outputFile))
                File.Delete(outputFile);

            List<Student> list = new List<Student>();
            Student stud1 = Student.ReadFromFile(inputFile1);
            Student stud2 = Student.ReadFromFile(inputFile2);

            list.Add(stud1); list.Add(stud2);
            list[0].Sort(); list[1].Sort();

            list[0].WriteToFile(outputFile);
            list[1].WriteToFile(outputFile);

            WriteToFile(string.Format("'{0}' ilgiausiai veikiantis įrenginys: '{1}'", list[0].GetName(), list[0].FindLongestBatteryLifeDevice().GetName()), outputFile);
            WriteToFile(string.Format("'{0}' ilgiausiai veikiantis įrenginys: '{1}'", list[1].GetName(), list[1].FindLongestBatteryLifeDevice().GetName()), outputFile);

            Console.Write("Įveskite norimą įrenginio tipą: ");
            var deviceList = FindSpecifiedTypeDevices(list, Console.ReadLine());

            WriteToFile("", outputFile);
            WriteToFile("Įrenginių sąrašas (nerikiuotas)", outputFile);
            Device.WriteDevicesToFile(deviceList, outputFile);
            Device.Sort(deviceList);
            WriteToFile("Įrenginių sąrašas (rikiuotas)", outputFile);
            Device.WriteDevicesToFile(deviceList, outputFile);
        }

        static List<Device> FindSpecifiedTypeDevices(List<Student> source, string type) {
            List<Device> result = new List<Device>();

            foreach(var stud in source) {
                for(Node elem = stud.GetHead(); elem._next != null; elem = elem._next) {
                    if(elem.Get().GetType() == type)
                        result.Add(elem.Get());
                }
            }

            return result;
        }

        static void WriteToFile(string line, string outputFile) {
            using(var writer = File.AppendText(outputFile))
                writer.WriteLine(line);
        }
    }
}
