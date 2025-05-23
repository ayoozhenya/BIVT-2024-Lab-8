using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_2 : Green
    {
        private char[] _output;
        public char[] Output => _output;
        public Green_2(string input) : base(input)
        {
            _output = null;
        }
        public override void Review()
        {
            string text = Input.ToLower();
            char[] letters = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                                  'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                                  'u', 'v', 'w', 'x', 'y', 'z'};

            char[] delimiters = { ' ', '.', '!', '?', ',', ':', '\"',';',
                                  '–', '(', ')', '[', ']', '{', '}', '/'};

            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int[] c = new int[letters.Length];
            int total = 0;
            for (int i = 0; i < words.Length; i++)
            {
                char first = words[i][0];
                for (int j = 0; j < letters.Length; j++)
                {
                    if (first == letters[j])
                    {
                        c[j]++;
                        total++;
                        break;
                    }
                }
            }
            if (total == 0)
            {
                _output = new char[0];
                return;
            }
            int n = 0;
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] > 0)
                {
                    n++;
                }
            }
            (char, int)[] time = new (char, int)[n];
            int index = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                if (c[i] > 0)
                {
                    time[index] = (letters[i], c[i]);
                    index++;
                }
            }
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < time.Length - 1; i++)
                {
                    if (time[i].Item2 < time[i + 1].Item2 ||
                       (time[i].Item2 == time[i + 1].Item2 && time[i].Item1 > time[i + 1].Item1))
                    {
                        var temp = time[i];
                        time[i] = time[i + 1];
                        time[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
            _output = new char[time.Length];
            for (int i = 0; i < time.Length; i++)
            {
                _output[i] = time[i].Item1;
            }
        }
        public override string ToString()
        {
            if (Output == null || Output.Length == 0)
            {
                return string.Empty;
            }

            return string.Join(", ", _output);
        }
    }
}
