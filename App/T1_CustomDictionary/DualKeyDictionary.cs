using System;
using System.Collections.Generic;

namespace App.T1_CustomDictionary;

    public class DualKeyDictionary<TValue>
    {
        private readonly Dictionary<int, TValue> _intDictionary;
        private readonly Dictionary<string, TValue> _stringDictionary;

        public DualKeyDictionary()
        {
            _intDictionary = new Dictionary<int, TValue>();
            _stringDictionary = new Dictionary<string, TValue>();
        }

        public TValue this[int id]
        {
            get
            {
                if (!_intDictionary.TryGetValue(id, out TValue value))
                {
                    throw new KeyNotFoundException();
                }
                return value;
            }
            set
            {
                _intDictionary[id] = value;
            }
        }

        public TValue this[string key]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException();
                }

                if (!_stringDictionary.TryGetValue(key, out TValue value))
                {
                    throw new KeyNotFoundException();
                }
                return value;

            }
            set
            {
                if (key == null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                _stringDictionary[key] = value;
            }
        }
    }
