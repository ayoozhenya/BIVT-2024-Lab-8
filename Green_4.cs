using System;
using System.Text;

namespace Lab_8
{
    public class Green_4 : Green
    {
        private string[] _output;
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

        public Green_4(string input) : base(input)
        {
            Review(); // Вызов анализа после инициализации
        }

        public override void Review()
        {
            if (_outputSet) return;

            if (string.IsNullOrEmpty(Input))
            {
                Output = new string[0];
                return;
            }

            string[] temp = new string[Input.Length];
            int surnameCount = 0;
            int start = 0;
            bool inSurname = false;

            for (int i = 0; i <= Input.Length; i++)
            {
                if (i == Input.Length || Input[i] == ',')
                {
                    if (inSurname)
                    {
                        string surname = Input.Substring(start, i - start).Trim();
                        if (surname.Length > 0 && !ContainsSurname(temp, surnameCount, surname))
                        {
                            temp[surnameCount++] = surname;
                        }
                        inSurname = false;
                    }
                    if (i < Input.Length && Input[i] == ',') start = i + 1;
                }
                else if (!char.IsWhiteSpace(Input[i]) && !inSurname)
                {
                    start = i;
                    inSurname = true;
                }
            }

            var output = new string[surnameCount];
            Array.Copy(temp, output, surnameCount);

            for (int i = 0; i < output.Length - 1; i++)
            {
                for (int j = 0; j < output.Length - i - 1; j++)
                {
                    if (string.Compare(output[j], output[j + 1], StringComparison.Ordinal) > 0)
                    {
                        string tempSurname = output[j];
                        output[j] = output[j + 1];
                        output[j + 1] = tempSurname;
                    }
                }
            }

            Output = output;
        }

        private bool ContainsSurname(string[] surnames, int count, string surname)
        {
            for (int i = 0; i < count; i++)
            {
                if (string.Equals(surnames[i], surname, StringComparison.Ordinal))
                    return true;
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