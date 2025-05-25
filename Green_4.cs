using System;
namespace Lab_8
{
    public class Green_4 : Green
    {
        private string[] _output;
        public string[] Output => _output;

        public Green_4(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (Input == null || Input.Length == 0)
            {
                _output = new string[0];
                return;
            }

            string[] surnames = Input.Split(
                new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
            );

            bool[] isDuplicate = new bool[surnames.Length];
            int uniqueCount = 0;

            for (int i = 0; i < surnames.Length; i++)
            {
                if (!isDuplicate[i])
                {
                    uniqueCount++;
                    for (int j = i + 1; j < surnames.Length; j++)
                    {
                        if (surnames[i].ToLower() == surnames[j].ToLower())
                        {
                            isDuplicate[j] = true;
                        }
                    }
                }
            }

            string[] uniqueSurnames = new string[uniqueCount];
            int index = 0;
            for (int i = 0; i < surnames.Length; i++)
            {
                if (!isDuplicate[i])
                {
                    uniqueSurnames[index++] = surnames[i];
                }
            }

            Array.Sort(uniqueSurnames, StringComparer.Ordinal);

            _output = uniqueSurnames;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
            {
                return "";
            }

            string result = "";

            for (int i = 0; i < _output.Length; ++i)
            {
                result += $"{_output[i]}";
                if (i + 1 < _output.Length)
                {
                    result += Environment.NewLine;
                }
            }
            return result;
        }
    }
}