namespace G06_20231008
{
    public class MyList<T> : CollectionBase<T>, IList<T>
    {
        public void Add(T item)
        {
            if (Count == _items.Length)
            {
                Resize(ref _items, _items.Length * 2);
            }
            _items[Count++] = item;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i; 
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index >= Count) throw new IndexOutOfRangeException(index.ToString());

            if (Count == _items.Length)
            {
                Resize(ref _items, _items.Length * 2);
            }
            Count++;

            for (int i = Count - 1; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[index] = item;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < _items.Length - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            Count--;
        }

        public T this[int index]
        {
            get
            {
                if (index >= Count) throw new IndexOutOfRangeException(index.ToString());

                return _items[index];
            }
            set
            {
                if (index >= Count) throw new IndexOutOfRangeException(index.ToString());

                _items[index] = value;
            }
        }
    }
}