namespace G06_20231008
{
	public class MyQueue<T> : CollectionBase<T>
	{
        public void Enqueue(T item)
        {
            if (Count == _items.Length)
            {
                Resize(ref _items, _items.Length * 2);
            }
            _items[Count] = item;
            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                Console.WriteLine("Queue is empty");
            }
            T array = _items[_index];
            _items[_index] = default(T);
            _index = _index + 1;
            Count--;

            return array;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new Exception("Stack is empty");
            }
            return _items[_index];
        }
    }
}
