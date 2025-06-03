using System;
using System.Text;

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
        }

        public override void Review()
        {
            if (_outputSet) return;
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_given))
            {
                Output = new string[0];
                return;
            }

            string text = Input.ToLower();
            string given = _given.ToLower().Trim();
            char[] delimiters = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };

            string[] temp = new string[Input.Length];
            int wordCount = 0;

            int start = 0;
            bool inWord = false;
            for (int i = 0; i <= text.Length; i++)
            {
                if (i == text.Length)
                {
                    if (inWord)
                    {
                        string word = text.Substring(start, i - start);
                        if (ContainsSubstring(word, given))
                        {
                            if (!ContainsWord(temp, wordCount, word))
                            {
                                temp[wordCount++] = word;
                            }
                        }
                    }
                    break;
                }

                bool isDelimiter = false;
                foreach (char d in delimiters)
                {
                    if (text[i] == d)
                    {
                        isDelimiter = true;
                        break;
                    }
                }

                if (isDelimiter)
                {
                    if (inWord)
                    {
                        string word = text.Substring(start, i - start);
                        if (ContainsSubstring(word, given))
                        {
                            if (!ContainsWord(temp, wordCount, word))
                            {
                                temp[wordCount++] = word;
                            }
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

            Output = new string[wordCount];
            Array.Copy(temp, Output, wordCount);
        }

        private bool ContainsSubstring(string word, string substring)
        {
            if (substring.Length > word.Length) return false;

            for (int i = 0; i <= word.Length - substring.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < substring.Length; j++)
                {
                    if (word[i + j] != substring[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match) return true;
            }
            return false;
        }

        private bool ContainsWord(string[] words, int count, string word)
        {
            for (int i = 0; i < count; i++)
            {
                if (words[i] == word) return true;
            }
            return false;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return string.Empty;

            return string.Join(Environment.NewLine, _output);
        }
    }
}