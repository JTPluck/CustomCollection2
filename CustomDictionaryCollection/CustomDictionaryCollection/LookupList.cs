using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionaryCollection
{

    public class LookupList<T1, T2> : IEnumerable, ILookupList<T1, T2>
    {

        /// <summary>
        /// Create a new list with generic key value pairs. On instantiation arguments will be strongly typed.
        /// </summary>
        private List<Lookup<T1, T2>> _list = new List<Lookup<T1, T2>>();
        private IEqualityComparer<T1> comparer;


        public LookupList()
        {
            this.comparer = EqualityComparer<T1>.Default;
        }

        public LookupList(IEqualityComparer<T1> comparer)
        {
            this.comparer = comparer ?? EqualityComparer<T1>.Default;
        }


        public void Add(T1 arg1, T2 arg2)
        {
            try
            {
                int hashCode = comparer.GetHashCode(arg1);
                for (int i = 0; i < _list.Count; i++)
                {
                    if (hashCode == comparer.GetHashCode(_list[i].Key) && comparer.Equals(_list[i].Key, arg1))
                        throw new ExceptionHelper("Duplicate key");
                }
                _list.Add(new Lookup<T1, T2>(arg1, arg2));
            }
            catch (Exception ex)
            {
                //LogError Then throw (class not implemented)
                throw new ExceptionHelper("Failed to add item Details: {0}", ex.Message);
            }
        }

        /// <summary>
        /// Required to allow for enumration over the list
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Find a particular items in the list by the key and remove it
        /// </summary>
        /// <param name="key"></param>
        public void Remove(T1 key)
        {
            try
            {
                int i = GetKeyIndex(key);
                if (i >= 0)
                {
                    _list.RemoveAt(i);
                }
            }
            catch (Exception)
            {
                //LogError Then throw (class not implemented)
                throw new ExceptionHelper("Delete Fail");
            }
        }

        /// <summary>
        /// Clear all items from the list
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }


        /// <summary>
        /// Finds the index of the key first by hash code then by key value.
        /// Hash codes are not unique so we also need to check the key. 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int GetKeyIndex(T1 key)
        {
            if (key == null)
            {
                throw new ExceptionHelper("Key cannot be null");
            }

            if (_list != null)
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    int hash = comparer.GetHashCode(key);
                    if (hash == comparer.GetHashCode(_list[i].Key) && comparer.Equals(_list[i].Key, key))
                        return i;
                }
            }
            return -1;
        }

        public bool TryGetValue(T1 key, out T2 value)
        {
            int index = GetKeyIndex(key);
            if (index >= 0)
            {
                value = _list[index].Value;
                return true;
            }
            else
                value = default(T2);
            return false;
        }

        /// <summary>
        /// Implements [] operator. Returns value by key provided. 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T2 this[T1 key]
        {
            get
            {
                int i = GetKeyIndex(key);
                if (i >= 0)
                {
                    return _list[i].Value;
                }
                return default(T2);
            }
        }

        /// <summary>
        /// Property to return all values contained in the list
        /// </summary>
        public List<T2> Values
        {
            get
            {
                List<T2> listValues = new List<T2>();
                foreach (Lookup<T1, T2> item in _list)
                {
                    listValues.Add(item.Value);
                }
                return listValues;
            }
        }

        /// <summary>
        /// Property to return all keys contained in the list
        /// </summary>
        public List<T1> Keys
        {
            get
            {
                List<T1> listKeys = new List<T1>();
                foreach (Lookup<T1, T2> item in _list)
                {
                    listKeys.Add(item.Key);
                }
                return listKeys;
            }
        }

    }
}
