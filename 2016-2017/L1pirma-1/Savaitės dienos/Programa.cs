using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savaitės_dienos
{
    class Programa
    {
        static void Main(string[] args)
        {
            string diena;

            Console.Write("Kokia šiandien savaitės diena? ");
            diena = Console.ReadLine().ToLower();

            switch (diena)
            {
                case "pirmadienis":
                    Console.WriteLine("Pirmadienis - sudėtingiausia savaitės diena.");
                    break;
                case "antradienis":
                    Console.WriteLine("Antradienis - aktyvių veiksmų, Marso diena.");
                    break;
                case "trečiadienis":
                    Console.WriteLine("Trečiadienis - sandoriams sudaryti " + "tinkamiausia diena.");
                    break;
                case "ketvirtadienis":
                    Console.WriteLine("Ketvirtadienį reikėtų imtis " + "visuomeninių darbų.");
                    break;
                case "penktadienis":
                    Console.WriteLine("Penktadienį lengvai gimsta šedevrai " + "susitinka mylimieji.");
                    break;
                case "šeštadienis":
                    Console.WriteLine("Šeštadienis - savo problemų " + "sprendimo diena.");
                    break;
                case "sekmadienis":
                    Console.WriteLine("Sekmadienį reikėtų pradėti " + "naujus darbus.");
                    break;
                default:
                    Console.WriteLine("Tokios savaitės dienos " + "pas mus nebūna.");
                    break;

            }
        }
    }
}
