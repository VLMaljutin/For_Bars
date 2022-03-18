using System;
var worker = new Test();
worker.OnError += LogError;
worker.OnKeyPressed += (o,name) => Console.WriteLine($"Введённый символ {name}");;
worker.Run();
static void LogError(object sender, Exception e) {
    Console.WriteLine(e.Message); 
}
        
public class Test
{
    public event EventHandler<Exception> OnError;
    public event EventHandler<char> OnKeyPressed;
    public void Run()
    {
       try
       {
            while (true)
            {
                char name = char.Parse(Console.ReadLine());
                OnKeyPressed?.Invoke(this, name);
                if (name == 'c') break; //Английская
                if (name == 'с') break; //Русская
            }
       }
       catch(Exception ex)
       {
            OnError?.Invoke(this, ex);
       }
        }
    }
    

