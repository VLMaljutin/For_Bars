using System;

namespace For_Bars
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Test();
            worker.OnKeyPressed += (o,name) => Console.WriteLine($"Введённый символ {name}");;
            worker.Run();
        }

    }

    public class Test
    {
        public event EventHandler<char> OnKeyPressed;
        public void Run()
        {
            while (true)
            {
                char name = char.Parse(Console.ReadLine());
                if (name == 'c' ) break; //Английская
                if (name == 'с' ) break; //Русская
                OnKeyPressed?.Invoke(this, name);
            }
        }
    }
    
}
