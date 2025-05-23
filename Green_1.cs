using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_1 : Green
    {
        private (char, double)[] _output;
        public (char, double)[] Output => _output;
        public Green_1(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            string t = Input.ToLower();
            char[] l = new char[]
            {
                'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й',
                'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф',
                'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
            };
            int[] count = new int[l.Length];
            int total = 0;

            for (int i = 0; i < t.Length; i++)
            {
                char a = t[i];
                for (int j = 0; j < l.Length; j++)
                {
                    if (a == l[j])
                    {
                        count[j]++;
                        break;
                    }
                }
                if (char.IsLetter(a)) { total++; }
            }

            if (total == 0)
            {
                _output = new (char, double)[0];
                return;
            }

            int k = 0;
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > 0)
                {
                    k++;
                }
            }

            (char, double)[] result = new (char, double)[k];
            int index = 0;
            for (int i = 0; i < l.Length; i++)
            {
                if (count[i] > 0)
                {
                    result[index] = (l[i], (double)count[i] / total);
                    index++;
                }
            }
            _output = result;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
            {
                return string.Empty;
            }
            return string.Join(Environment.NewLine, Output.Select(pair => $"{pair.Item1} - {pair.Item2:F4}"));
        }

    }
}
