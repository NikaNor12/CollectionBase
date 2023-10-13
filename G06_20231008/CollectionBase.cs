using System;
using System.Collections;

namespace G06_20231008
{
    public abstract class CollectionBase<T> : ICollection<T>
    {
        protected T[] _items;
        protected int _index;
        public CollectionBase()
        {
            _items = new T[4];
        }

        public void Clear()
        {
            Array.Resize(ref _items, 0);
            Count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item)) 
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(_items[i], arrayIndex++);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnumerator<T>(_items, Count);
        }

        bool ICollection<T>.IsReadOnly { get; }

        public bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item)) 
                {               
                    for (int j = i; j < Count - 1; j++)
                    {
                        _items[j] = _items[j + 1];    // amaze kargad vixrweni.
                    }
                    _items[Count - 1] = default(T);  
                    Count--;
                    return true;
                }
            }

            return false;
        }

        public void TrimToSize()
        {
            Resize(ref _items, Count);
        }

        public static void Resize(ref T[] array, int size)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Length == size) return;

            T[] newArray = new T[size];
            for (int i = 0; i < array.Length && i < newArray.Length; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }

        public int Count { get; protected set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void ICollection<T>.Add(T item)
        {
            Array.Resize(ref _items, _items.Length + 1);
            _items[_items.Length - 1] = item;
        }

        public class MyListEnumerator<T> : IEnumerator<T>
        {
            private T[] _items;
            private int _size;
            private int _index;

            public MyListEnumerator(T[] items, int size)
            {
                _items = items;
                _size = size;
                _index = -1;
            }

            public bool MoveNext()
            {
                if (_index + 1 < _size)
                {
                    _index++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _index = -1;
            }

            public T Current
            {
                get
                {
                    return _items[_index];
                }
            }

            object IEnumerator.Current => Current;

            public int Count { get; private set; }

            public void Dispose()
            {
                // 
            }
        }
    }
}
