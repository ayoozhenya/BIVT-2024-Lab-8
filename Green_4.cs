using System;
using System.Text;
using System.Linq;

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

            var surnames = Input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrEmpty(s))
                .Distinct()
                .OrderBy(s => s, StringComparer.Ordinal)
                .ToArray();

            Output = surnames;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return string.Empty;

            return string.Join(Environment.NewLine, _output);
        }
    }
}