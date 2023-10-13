using G19_20230916;

namespace G06_20231008
{
	public class MyStack<T> : enumeratorForStack<T>
    {
        public void Push(T? item)
        {

            if (Count == _items.Length)
            {
                Resize(ref _items, _items.Length * 2);
            }

            _items[Count] = item;

            Count++;
        }

        public T Pop()
		{
			if (Count == 0)
			{
                Console.WriteLine("Stack is empty");
            }
			T item = Peek();
			Array.Resize(ref _items, Count - 1);
			return item;
		}

		public T Peek()
		{
			if (Count == 0)
			{
                Console.WriteLine("Stack is empty");
            }
			return _items[_items.Length - 1];
		}
	}
}
