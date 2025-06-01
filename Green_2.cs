using System;
using System.Text;

namespace Lab_8
{
    public class Green_2 : Green
    {
        private char[] _output;
        public char[] Output => _output;
        private static readonly char[] russianLetters = {
            'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й',
            'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у',
            'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
        };

        public Green_2(string input) : base(input) { }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = new char[0];
                return;
            }

            string text = Input.ToLower();
            char[] delimiters = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            int[] counts = new int[russianLetters.Length];
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
                        for (int i = 0; i < russianLetters.Length; i++)
                        {
                            if (firstChar == russianLetters[i])
                            {
                                counts[i]++;
                                totalWords++;
                                break;
                            }
                        }
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
                _output = new char[0];
                return;
            }

            int resultCount = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 0) resultCount++;
            }

            (char, int)[] letters = new (char, int)[resultCount];
            int index = 0;
            for (int i = 0; i < russianLetters.Length; i++)
            {
                if (counts[i] > 0)
                {
                    letters[index++] = (russianLetters[i], counts[i]);
                }
            }

            for (int i = 0; i < letters.Length - 1; i++)
            {
                for (int j = 0; j < letters.Length - i - 1; j++)
                {
                    if (letters[j].Item2 < letters[j + 1].Item2 ||
                       (letters[j].Item2 == letters[j + 1].Item2 && letters[j].Item1 > letters[j + 1].Item1))
                    {
                        var temp = letters[j];
                        letters[j] = letters[j + 1];
                        letters[j + 1] = temp;
                    }
                }
            }

            _output = new char[letters.Length];
            for (int i = 0; i < letters.Length; i++)
            {
                _output[i] = letters[i].Item1;
            }
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