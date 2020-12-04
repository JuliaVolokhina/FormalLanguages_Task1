using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalLanguages_Task1
{
    class Automaton
    {
        private Dictionary<KeyValuePair<int, string>, int> Transitions;
        public int currentState { get; set; }

        public Automaton()
        {
            this.Transitions = new Dictionary<KeyValuePair<int, string>, int>();
            this.currentState = 1;
        }
        public Automaton(Dictionary<KeyValuePair<int, string>, int> transitions, int currentState)
        {
            this.Transitions = transitions;
            this.currentState = currentState;
        }

        public KeyValuePair<KeyValuePair<int, string>, int>[] AutomatonTransitions
        {
            set
            {
                this.Transitions = value.ToDictionary(x => x.Key, y => y.Value);
            }
            get
            {
                return this.Transitions.ToArray();
            }
        }

        public KeyValuePair<bool, int> GetValues(string inputString, int offset)
        {
            bool isIntValue = false;
            int symbols = 0;
            int index = offset;
            while (index < inputString.Length)
            {
                string substring = inputString[index].ToString();
                if (Transitions.ContainsKey(new KeyValuePair<int, string>(currentState, substring)))
                {
                    isIntValue = true;
                    symbols++;
                    currentState = Transitions[new KeyValuePair<int, string>(currentState, substring)];
                    index++;
                }
                else
                {
                    break;
                }
            }
            return new KeyValuePair<bool, int>(isIntValue, symbols);
        }
    }
}
