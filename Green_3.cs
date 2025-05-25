using System;
namespace Lab_8
{
    public class Green_3 : Green
    {
        private string[] _output;
        private string _given;

        public string[] Output => _output;

        public Green_3(string input, string given) : base(input)
        {
            _output = null;
            _given = given ?? throw new ArgumentNullException(nameof(given));
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_given))
            {
                _output = new string[0];
                return;
            }

            string text = Input;
            char[] delimiters = { ' ', '.', '!', '?', ',', ':', '\"', ';',
                                  '–', '(', ')', '[', ']', '{', '}', '/' };

            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (ContainsSubstring(words[i], _given))
                {
                    count++;
                }
            }

            string[] result = new string[count];
            int index = 0;
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].Trim();
                if (ContainsSubstring(words[i], _given))
                {
                    result[index++] = words[i].ToLower();
                }
            }

            int uniqueCount = 0;
            bool[] used = new bool[result.Length];

            for (int i = 0; i < result.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    uniqueCount++;

                    for (int j = i + 1; j < result.Length; j++)
                    {
                        if (!used[j] && AreEqualIgnoreCase(result[i], result[j]))
                        {
                            used[j] = true;
                        }
                    }
                }
            }

            string[] unique = new string[uniqueCount];
            int k = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (used[i])
                {
                    unique[k++] = result[i];
                }
            }

            _output = unique;
        }

        private bool ContainsSubstring(string text, string sub)
        {
            text = text.ToLower();
            sub = sub.ToLower();

            for (int i = 0; i <= text.Length - sub.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < sub.Length; j++)
                {
                    if (text[i + j] != sub[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match) return true;
            }
            return false;
        }

        private bool AreEqualIgnoreCase(string a, string b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (char.ToLower(a[i]) != char.ToLower(b[i])) return false;
            }
            return true;
        }

        public override string ToString()
        {
            return Output == null || Output.Length == 0
                ? string.Empty
                : string.Join(Environment.NewLine, Output);
        }
    }
}