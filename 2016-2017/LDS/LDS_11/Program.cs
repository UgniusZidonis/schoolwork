using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LDS_11
{
    class Program
    {
        const string CFmorse = "../../morse.txt";
        const string CFin = "../../input.txt";
        static void Main(string[] args)
        {
            string[] morse = File.ReadAllLines(CFmorse);
            string[] words = lineToWordArray(File.ReadAllText(CFin));

            WriteToConsole(words, morse);

            /*---*/
            Console.WriteLine("\nPrograma baigė darbą...");
        }

        static string[] lineToWordArray(string line) {
            string[] words = line.Split(' ');
            words[words.Length - 1] = words[words.Length - 1].Trim('.');

            return words;
        }

        static string[] WordToMorse(string word, string[] morse) {
            string[] output = new string[word.Length];

            for (int i = 0; i < word.Length; i++) {
                output[i] = morse[char.ToLower(word[i]) - 97];
            }

            return output;
        }

        static void WriteToConsole(string[] words, string[] morse) {
            for (int word = 0; word < words.Length; word++) {
                string[] wordsMorse = WordToMorse(words[word], morse);

                for (int i = 0; i < wordsMorse.Length; i++) {
                    if (i != wordsMorse.Length - 1)
                        Console.Write(wordsMorse[i] + " ");
                    else
                        Console.Write(wordsMorse[i]);
                }

                if (word != words.Length - 1)
                    Console.WriteLine();
            }
        }
    }
}
