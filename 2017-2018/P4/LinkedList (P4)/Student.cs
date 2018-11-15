using System;
using System.IO;
using System.Collections.Generic;

namespace P4
{
    class Student
    {
        private string _name;
        LinkedList<Device> _list;

        public Student(string name)
        {
            _name = name;
            _list = new LinkedList<Device>();
        }

        public string GetName() { return _name; }

        public void Add(Device device)
        {
            _list.AddAfter(_list.Last.Previous, device);
        }

        public void Sort()
        {
            for (int i = 0; i < _list.Count; i++) {
                for (var elem = _list.First.Next; elem.Next.Value != null; elem = elem.Next) {
                    if (elem.Value <= elem.Next.Value)
                    {
                        var tmp = elem;
                        elem.Value = elem.Next.Value;
                        elem.Next.Value = tmp.Value;
                    }
                }
            }
        }

        public Device FindLongestBatteryLifeDevice()
        {
            Device result = _list.First.Value;
            foreach (var node in _list)
                if (node.GetBatteryLife() > result.GetBatteryLife())
                    result = node;

            return result;
        }

        public List<Device> FindSpecifiedTypeDevices(string type) {
            List<Device> result = new List<Device>();

            foreach (var node in _list)
                if (node.GetType() == type)
                    result.Add(node);

            return result;
        }

        public static Student ReadFromFile(string inputFile)
        {
            Student student;
            using (StreamReader reader = new StreamReader(inputFile))
            {
                string line = reader.ReadLine();
                student = new Student(line);

                while ((line = reader.ReadLine()) != null)
                {
                    char[] chars = { ' ', ';' };
                    var parts = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    string name = parts[0];
                    string type = parts[1];
                    int battery = int.Parse(parts[2]);

                    student.Add(new Device(name, type, battery));
                }
            }

            return student;
        }

        public void WriteToFile(string outputFile)
        {
            using (var writer = File.AppendText(outputFile))
            {
                writer.WriteLine(_name);
                writer.WriteLine("+------------------------------+----------------------+--------------+");
                writer.WriteLine("|           Modelis            |         Tipas        | Veik. trukmė |");
                writer.WriteLine("+------------------------------+----------------------+--------------+");

                for (var node = _list.First; node.Value != null; node = node.Next)
                    writer.WriteLine(node.ToString());

                writer.WriteLine("+------------------------------+----------------------+--------------+");
            }
        }
    }
}