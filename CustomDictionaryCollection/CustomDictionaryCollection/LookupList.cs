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

        public void Add(T1 arg1, T2 arg2)
        {
            try
            {
                _list.Add(new Lookup<T1, T2>(arg1, arg2));
            }
            catch(Exception)
            {
                //LogError Then throw (class not implemented)
                throw new ExceptionHelper("Failed to add item");
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
        /// Custom Equals method accounts for string case sensitivity
        /// </summary>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <returns></returns>
        public bool KeyEquals(T1 key1, T1 key2)
        {
            if (key1.GetType() == typeof(String))
            {
                return string.Equals(key1.ToString(), key2.ToString(), StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                return key1.Equals(key2);
            }
        }
        
        /// <summary>
        /// Returns the first occurance of the key in the list otherwise returns false
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(T1 key)
        {
            foreach (Lookup<T1, T2> item in _list)
            {
                if (KeyEquals(key, item.Key) == true)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Find a particular items in the list by the key and remove it
        /// </summary>
        /// <param name="key"></param>
        public void Remove(T1 key)
        {
            Lookup<T1, T2> Lookup;
            try
            {
                if (TryGetValue(key, out Lookup))
                {
                    _list.Remove(Lookup);
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
        /// Finds the value by key and returns the value in an out variable
        /// </summary>
        /// <param name="key"></param>
        /// <param name="Lookup"></param>
        /// <returns></returns>
        public bool TryGetValue(T1 key, out Lookup<T1, T2> Lookup)
        {
            Lookup = null;
            if (!ContainsKey(key))
            {
                throw new ExceptionHelper("Key not found");
            }
            foreach (Lookup<T1, T2> item in _list)
            {
                if (KeyEquals(key, item.Key) == true)
                {
                    Lookup = item;
                    return true;
                }
            }
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
                if (!ContainsKey(key))
                {
                    throw new ExceptionHelper("Key not found");
                }
                foreach (Lookup<T1, T2> item in _list)
                {
                    if (KeyEquals(key, item.Key) == true)
                    {
                        return item.Value;
                    }
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
