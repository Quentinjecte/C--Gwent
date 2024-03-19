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
        public str_func(string str, Action func)
                {
                    _str = str;
                    _func = func;
                }

                string _str;
                public string Str {  get { return _str; } }
                readonly Action _func;
                public Action Func { get {  return _func; } }

/*
        Dictionary<string, Action> Dic_Func = new Dictionary<string, Action>();

        public str_func()
        {
        }*/
    }
}
