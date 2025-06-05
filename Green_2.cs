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
            Review();
        }

        public override void Review()
        {
            if (_outputSet) return;

            if (string.IsNullOrEmpty(Input))
            {
                Output = Array.Empty<char>();
                return;
            }

            string text = Input.ToLower();
            char[] delimiters = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '-', '(', ')', '[', ']', '{', '}', '/', '<', '>', '«', '»' };
            Dictionary<char, int> counts = new Dictionary<char, int>();

            bool inWord = false;
            char firstChar = '\0';

            foreach (char c in text + " ")
            {
                bool isDelimiter = delimiters.Contains(c);

                if (isDelimiter || c == ' ' || c == '\t' || c == '\n')
                {
                    if (inWord && firstChar != '\0' && char.IsLetter(firstChar))
                    {
                        if (counts.ContainsKey(firstChar))
                            counts[firstChar]++;
                        else
                            counts[firstChar] = 1;
                    }
                    inWord = false;
                    firstChar = '\0';
                }
                else if (!inWord && char.IsLetter(c))
                {
                    firstChar = c;
                    inWord = true;
                }
            }

            if (counts.Count == 0)
            {
                Output = Array.Empty<char>();
                return;
            }

            Output = counts
                .OrderByDescending(pair => pair.Value)  
                .ThenBy(pair => pair.Key)               
                .Select(pair => pair.Key)
                .ToArray();
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return string.Empty;

            return string.Join(", ", _output);
        }
    }
}