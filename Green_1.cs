using System;
using System.Text;
using System.Linq;

namespace Lab_8
{
    public class Green_1 : Green
    {
        private (char, double)[] _output;
        private bool _outputSet = false;
        public (char, double)[] Output
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
        private static readonly char[] russianLetters = {
            'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й',
            'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у',
            'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
        };

        public Green_1(string input) : base(input)
        {
            Review();
        }

        public override void Review()
        {
            if (_outputSet) return;

            if (string.IsNullOrEmpty(Input))
            {
                Output = null;
                return;
            }

            string text = Input.ToLower();
            int[] counts = new int[russianLetters.Length];
            int totalLetters = 0;

            foreach (char c in text)
            {
                for (int i = 0; i < russianLetters.Length; i++)
                {
                    if (c == russianLetters[i])
                    {
                        counts[i]++;
                        totalLetters++;
                        break;
                    }
                }
            }

            if (totalLetters == 0)
            {
                Output = new (char, double)[0];
                return;
            }

            var output = russianLetters
                .Select((c, i) => (c, (double)counts[i] / totalLetters))
                .Where(x => x.Item2 > 0)
                .OrderBy(x => x.c)
                .ToArray();

            Output = output;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (var item in _output)
            {
                sb.AppendLine($"{item.Item1} - {item.Item2:F4}");
            }
            return sb.ToString().Trim();
        }
    }
}