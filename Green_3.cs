using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _given = given;
        }
        public override void Review()
        {
            string text = Input;
            char[] delimiters = { ' ', '.', '!', '?', ',', ':', '\"',';',
                                  '–', '(', ')', '[', ']', '{', '}', '/'};
            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int c = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].IndexOf(_given, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    c++;
                }
            }
            string[] fws = new string[c];
            int index = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].IndexOf(_given, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    fws[index] = words[i].ToLower();
                    index++;
                }
            }
            _output = fws.Distinct().ToArray();
        }
        public override string ToString()
        {
            return Output == null || Output.Length == 0
                ? string.Empty
                : string.Join(Environment.NewLine, Output);
        }
    }
}
