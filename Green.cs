using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    abstract public class Green
    {
        private string _input;
        public string Input { get { return _input; } }
        public Green(string input)
        {
            _input = input;
        }
        public abstract void Review();
    }
}