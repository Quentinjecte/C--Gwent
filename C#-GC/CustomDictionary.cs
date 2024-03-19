using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{
    struct str_func
    {
        public str_func(string str, Func<int, int> func)
        {
            _str = str;
            _func = func;
        }

        string _str;
        public string Str {  get { return _str; } }
        Func<int, int> _func;
        public Func<int, int> Func { get {  return _func; } }
    }
}
