using System.Collections.Generic;
using System.IO;

namespace P4
{
    class Device
    {
        private string _name;
        private string _type;
        private int _batteryLife;

        public Device(string name = "", string type = "", int batteryLife = 0) {
            _name = name;
            _type = type;
            _batteryLife = batteryLife;
        }

        public string GetName() { return _name; }

        public string GetType() { return _type; }

        public int GetBatteryLife() { return _batteryLife; }

        public override string ToString() {
            return string.Format("| {0,28} | {1,20} | {2,12:d} |", _name, _type, _batteryLife);
        }

        public static bool operator <=(Device lhs, Device rhs) {
            if(rhs == null)
                return false;

            int b = lhs._batteryLife < rhs._batteryLife ? -1 : lhs._batteryLife == rhs._batteryLife ? 0 : 1;
            int s = string.Compare(lhs._name, rhs._name);

            return b > 0 || (b == 0 && s < 0) || (b == 0 && s == 0);
        }

        public static bool operator >=(Device lhs, Device rhs) {
            if(rhs == null)
                return true;

            int b = lhs._batteryLife < rhs._batteryLife ? -1 : lhs._batteryLife == rhs._batteryLife ? 0 : 1;
            int s = string.Compare(lhs._name, rhs._name);

            return b < 0 ||
                   (b == 0 && s > 0) ||
                   (b == 0 && s == 0);
        }

        public bool EqualType(Device other) { return _type == other._type; }

        static public void Sort(List<Device> target) {
            for(int i = 0; i < target.Count - 1; i++) {
                var maxI = i;
                for(int j = i + 1; j < target.Count; j++) {
                    if(target[maxI] <= target[j])
                        maxI = j;
                }
                var tmp = target[maxI];
                target[maxI] = target[i];
                target[i] = tmp;
            }
        }

        static public void WriteDevicesToFile(List<Device> source, string outputFile) {
            using(var writer = File.AppendText(outputFile)) {
                if(source.Count == 0) {
                    writer.WriteLine("!Sąrašas tuščias!");
                    return;
                }

                string header =
                    "+--------------------------------------------------------------------+\r\n" +
                    "|           Modelis            |         Tipas        | Veik. trukmė |\r\n" +
                    "+--------------------------------------------------------------------+";

                writer.WriteLine(header);

                foreach(var dev in source) {
                    writer.WriteLine(dev.ToString());
                }

                writer.WriteLine("+--------------------------------------------------------------------+");
            }
        }
    }
}
