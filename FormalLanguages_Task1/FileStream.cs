using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalLanguages_Task1
{
    class FileStream
    {
        Automaton automaton = null;
        public Automaton GetAutomaton(string filename)
        {
            char[] separators = new char[] { '\n' };
            string[] currentTransition = new string[3];
            int currentState = 0;
            Dictionary<KeyValuePair<int, string>, int> transitions = new Dictionary<KeyValuePair<int, string>, int>();
            using (StreamReader sr = new StreamReader(filename))
            {
                string[] readedValues = sr.ReadToEnd().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (int.TryParse(readedValues[0], out int state))
                {
                    currentState = state;
                }

                for (int i = 1; i < readedValues.Length; i++)
                {
                    currentTransition = readedValues[i].Split(' ');
                    if (int.TryParse(currentTransition[0], out int start))
                    {
                        if (int.TryParse(currentTransition[2], out int finish))
                        {
                            transitions.Add(new KeyValuePair<int, string>(start, currentTransition[1]), finish);
                        }
                    }
                }
            }

            automaton = new Automaton(transitions, currentState);
            return automaton;
        }
    }
}
