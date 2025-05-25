using System;
using System.Text;
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
            if (string.IsNullOrEmpty(Input))
            {
                _output = new (char, double)[0];
                return;
            }

            string text = Input.ToLower();

            char[] letters = new char[]
            {
                'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й',
                'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф',
                'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
            };

            int[] count = new int[letters.Length];
            int total = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                for (int j = 0; j < letters.Length; j++)
                {
                    if (c == letters[j])
                    {
                        count[j]++;
                        total++;
                        break;
                    }
                }
            }

            if (total == 0)
            {
                _output = new (char, double)[0];
                return;
            }

            int resultCount = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                if (count[i] > 0)
                {
                    resultCount++;
                }
            }

            (char letter, double freq)[] result = new (char, double)[resultCount];
            int index = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                if (count[i] > 0)
                {
                    result[index++] = (letters[i], (double)count[i] / total);
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

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _output.Length; i++)
            {
                sb.AppendLine($"{_output[i].letter} - {_output[i].freq:F4}");
            }
            return sb.ToString().Trim();
        }
    }
}