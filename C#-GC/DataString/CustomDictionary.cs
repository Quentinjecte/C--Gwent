using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace C__GC
{
    public struct str_func
    {
        private readonly string _str;
        private readonly int _i;
        private readonly Action _func;
        private readonly Action<string[]> _option;

        public str_func(string str)
        {
            _str = str;
        }

        public str_func(string str, Action func, int i)
        {
            _str = str;
            _i = i;
            _func = func;
            _option = null; // Option is not used here
        }

        public str_func(string str, Action<string[]> option, int i)
        {
            _str = str;
            _func = null; // Func is not used here
            _option = option;
        }

        public string Str { get { return _str; } }
        public int I { get { return _i; } }
        public Action Func { get { return _func; } }
        public Action<string[]> Option { get { return _option; } }

        public string V { get; }

        public void ExecuteAction()
        {
            _func?.Invoke();
            //Option.DynamicInvoke();
        }

    }
}
