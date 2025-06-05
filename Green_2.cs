using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Lab_8
{
    public class Green_2 : Green
    {
        private char[] _output;
        private bool _outputSet = false;
        public char[] Output
        {
            get => _output;
            private set
            {
                if (!_outputSet)
                {
                    _output = value;
                    _outputSet = true;
                }
            }
        }

        public Green_2(string input) : base(input)
        {
            Review(); // Вызов анализа после инициализации
        }

        public override void Review()
        {
            if (_outputSet) return;

            if (string.IsNullOrEmpty(Input))
            {
                Output = new char[0];
                return;
            }

            string text = Input.ToLower();
            char[] delimiters = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            Dictionary<char, int> counts = new Dictionary<char, int>();
            int totalWords = 0;

            bool inWord = false;
            char firstChar = '\0';
            foreach (char c in text + " ")
            {
                bool isDelimiter = false;
                foreach (char d in delimiters)
                {
                    if (c == d)
                    {
                        isDelimiter = true;
                        break;
                    }
                }

                if (isDelimiter || c == ' ')
                {
                    if (inWord && firstChar != '\0')
                    {
                        if (counts.ContainsKey(firstChar))
                            counts[firstChar]++;
                        else
                            counts[firstChar] = 1;
                        totalWords++;
                    }
                    inWord = false;
                    firstChar = '\0';
                }
                else if (!inWord)
                {
                    firstChar = c;
                    inWord = true;
                }
            }

            if (totalWords == 0)
            {
                Output = new char[0];
                return;
            }

            var letters = counts.ToList();
            letters.Sort((a, b) =>
            {
                int cmp = b.Value.CompareTo(a.Value);
                if (cmp == 0) return a.Key.CompareTo(b.Key);
                return cmp;
            });

            Output = letters.Select(x => x.Key).ToArray();
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _output.Length; i++)
            {
                if (i > 0) sb.Append(", ");
                sb.Append(_output[i]);
            }
            return sb.ToString();
        }
    }
}