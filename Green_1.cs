using System;
using System.Text;

namespace Lab_8
{
    public class Green_1 : Green
    {
        private (char, double)[] _output;
        public (char, double)[] Output => _output;
        private static readonly char[] russianLetters = {
            'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й',
            'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у',
            'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
        };

        public Green_1(string input) : base(input) { }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = new (char, double)[0];
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
                _output = new (char, double)[0];
                return;
            }

            int resultCount = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 0) resultCount++;
            }

            _output = new (char, double)[resultCount];
            int index = 0;
            for (int i = 0; i < russianLetters.Length; i++)
            {
                if (counts[i] > 0)
                {
                    _output[index++] = (russianLetters[i], Math.Round((double)counts[i] / totalLetters, 4));
                }
            }
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