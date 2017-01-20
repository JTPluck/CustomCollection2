using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionaryCollection
{
    interface ILookupList<T1, T2>
    {
        void Add(T1 arg1, T2 arg2);
        bool ContainsKey(T1 key);
        void Remove(T1 key);
        void Clear();
        bool TryGetValue(T1 key, out Lookup<T1, T2> Lookup);
        List<T1> Keys { get; }
        List<T2> Values { get; }
        bool KeyEquals(T1 key1, T1 key2);
    }
}
