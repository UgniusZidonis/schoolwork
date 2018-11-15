using System;
using System.IO;

namespace P4
{
    class Student
    {
        private string _name;
        private Node _head;
        private Node _last;
        public int _count { get; private set; }

        public Student(string name)
        {
            _name = name;
            _last = new Node(null);
            _head = new Node(null, _last);
            _count = 0;
        }

        public string GetName() { return _name; }

        public Node GetHead() { return _head._next; }

        public void Add(Device device)
        {
            var last = _head;
            while (last._next.Get() != null)
                last = last._next;

            last.SetNext(device);
            _count++;
        }

        public void Sort()
        {
            for (int i = 0; i < _count; i++) {
                for (var elem = _head._next; elem._next.Get() != null; elem = elem._next) {
                    if (elem.Get() <= elem._next.Get())
                    {
                        var tmp = elem._device;
                        elem._device = elem._next._device;
                        elem._next._device = tmp;
                    }
                }
            }
        }

        public Device FindLongestBatteryLifeDevice()
        {
            if (_head._next.Get() == null)
                return null;

            Device result = _head._next.Get();
            for (var elem = _head._next; elem.Get() != null; elem = elem._next)
                if (elem.Get().GetBatteryLife() > result.GetBatteryLife())
                    result = elem.Get();

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

                for (var node = _head._next; node.Get() != null; node = node._next)
                    writer.WriteLine(node.ToString());

                writer.WriteLine("+------------------------------+----------------------+--------------+");
            }
        }
    }
}