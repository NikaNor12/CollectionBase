using System.Collections;

namespace G19_20230916
{
    public abstract class enumeratorForStack<T> : IEnumerable<T>
    {
        protected T[] _items;
        protected int _index;

        public enumeratorForStack()
        {
            _items = new T[10];
            Count = 0;
            _index = 0;
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

        public bool IsReadOnly => throw new NotImplementedException();
        public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnumerator<T>(_items, Count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
                _index = _items.Length;
            }

            public bool MoveNext()
            {
                if (_index > 0)
                {
                    _index--;
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