using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionaryCollection
{
    public class Lookup<T1, T2>
    {
        public Lookup(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }

        public T1 Key { get; set; }
        public T2 Value { get; set; }
    }
}
