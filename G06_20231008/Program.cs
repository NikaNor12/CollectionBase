namespace G06_20231008
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("This is your list");

            MyList<string> list = new MyList<string>();
            list.Add("Nuca");
            list.Add("Gio");
            list.Add("Gela");
            list.Add("Jambula");
            list.Add("Davit");
            list.Add("Nina");
            list[1] = "Giorgi";
            list.Remove("Davit");
            list.Contains("Nina");

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}

            //Console.WriteLine("----");

            foreach (var name in list)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("This is your chosen index " + list.IndexOf("Jambula"));     
            
            Console.WriteLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("This is your queue");

            MyQueue<string> queue = new MyQueue<string>();
            queue.Enqueue("Nuca");
            queue.Enqueue("Mariam");
            queue.Enqueue("Nina");
            queue.Enqueue("Nino");
            queue.Enqueue("Nika");
            queue.Enqueue("Davit");

            foreach (string item in queue)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is your stack");
            MyStack<string> stack = new MyStack<string>();
            stack.Push("Nika");
            stack.Push("Gio");
            stack.Push("Nuca");
            stack.Push("Nina");
            stack.Push("Oto");
            stack.TrimToSize();

            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }

            Console.ResetColor();
        }
    }
}
