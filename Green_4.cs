using System;
using System.Text;

namespace Lab_8
{
    public class Green_4 : Green
    {
        private string[] _output;
        public string[] Output => _output;

        public Green_4(string input) : base(input) { }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = new string[0];
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

            _output = new string[surnameCount];
            Array.Copy(temp, _output, surnameCount);

            for (int i = 0; i < _output.Length - 1; i++)
            {
                for (int j = 0; j < _output.Length - i - 1; j++)
                {
                    if (string.Compare(_output[j], _output[j + 1], StringComparison.Ordinal) > 0)
                    {
                        string tempSurname = _output[j];
                        _output[j] = _output[j + 1];
                        _output[j + 1] = tempSurname;
                    }
                }
            }
        }

        private bool ContainsSurname(string[] surnames, int count, string surname)
        {
            for (int i = 0; i < count; i++)
            {
                if (string.Equals(surnames[i], surname, StringComparison.OrdinalIgnoreCase))
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