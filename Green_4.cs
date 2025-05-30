using System;
namespace Lab_8
{
    public class Green4 : Green
    {
        private string[] _output = Array.Empty<string>();

        public Green4(string input) : base(input)
        {
        }

        public override void Review()
        {
            string[] names = SplitNames();
            SortNames(names);

            _output = names;
        }

        private string[] SplitNames()
        {
            int count = 0;
            for (int i = 0; i < Input.Length; i++)
            {
                if (Input[i] == ',') count++;
            }

            string[] names = new string[count + 1];
            int start = 0;
            int index = 0;

            for (int i = 0; i <= Input.Length; i++)
            {
                char c = i < Input.Length ? Input[i] : ',';
                if (c == ',')
                {
                    while (start < i && char.IsWhiteSpace(Input[start])) start++;
                    while (i > start && char.IsWhiteSpace(Input[i - 1])) i--;

                    names[index++] = Input.Substring(start, i - start);
                    start = i + 1;
                }
            }

            return names;
        }

        private void SortNames(string[] names)
        {
            for (int i = 0; i < names.Length - 1; i++)
            {
                for (int j = 0; j < names.Length - i - 1; j++)
                {
                    if (CompareStrings(names[j], names[j + 1]) > 0)
                    {
                        (names[j], names[j + 1]) = (names[j + 1], names[j]);
                    }
                }
            }
        }

        private int CompareStrings(string a, string b)
        {
            int len = Math.Min(a.Length, b.Length);
            for (int i = 0; i < len; i++)
            {
                char ac = char.ToLower(a[i]);
                char bc = char.ToLower(b[i]);
                if (ac != bc) return ac - bc;
            }

            return a.Length - b.Length;
        }

        public override object Output => _output;

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < _output.Length; i++)
                result += _output[i] + "\n";

            return result.TrimEnd('\n');
        }
    }
}