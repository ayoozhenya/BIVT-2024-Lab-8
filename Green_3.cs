using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Lab_8
{
    public class Green_3 : Green
    {
        private string[] _output;
        private string _given;
        private bool _outputSet = false;

        public string[] Output
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

        public Green_3(string input, string given) : base(input)
        {
            _given = given ?? throw new ArgumentNullException(nameof(given));
            Review();
        }

        public override void Review()
        {
            if (_outputSet) return;
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_given))
            {
                Output = null;
                return;
            }

            string text = Input.ToLower();
            string given = _given.ToLower().Trim();
            char[] delimiters = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };

            var words = new List<string>();
            int start = 0;
            bool inWord = false;

            for (int i = 0; i <= text.Length; i++)
            {
                if (i == text.Length || delimiters.Contains(text[i]))
                {
                    if (inWord)
                    {
                        string word = text.Substring(start, i - start);
                        if (word.Contains(given) && !words.Contains(word))
                        {
                            words.Add(word);
                        }
                        inWord = false;
                    }
                }
                else if (!inWord)
                {
                    start = i;
                    inWord = true;
                }
            }

            Output = words.ToArray();
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return string.Empty;

            return string.Join(Environment.NewLine, _output);
        }
    }
}