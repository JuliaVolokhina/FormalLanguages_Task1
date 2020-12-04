using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalLanguages_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Automaton automaton = null;
            FileStream fs = new FileStream();
            automaton = fs.GetAutomaton("input.txt");

            foreach (var i in automaton.AutomatonTransitions)
            {
                Console.WriteLine("{0}: {1}", i.Key.ToString(), i.Value.ToString());
            }
            while (true)
            {
                Console.WriteLine("Text:");
                string inputText = Console.ReadLine();
                Console.WriteLine("Offset:");
                if (int.TryParse(Console.ReadLine(), out var offset))
                {
                    var result = automaton.GetValues(inputText, offset);
                    Console.WriteLine(result);

                    if (result.Key)
                    {
                        Console.WriteLine(inputText.Substring(offset, result.Value));
                    }
                }
                else
                {
                    Console.WriteLine("Offset is incorrected");
                }
                Console.ReadLine();
            }
        }
    }
}
