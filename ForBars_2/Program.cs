// Задание 1 - обобщение 
// Тип int
LocalFileLogger<int> x = new LocalFileLogger<int>("C:/Users/Vasiliy/source/repos/For_Bars/ForBars_2/Test.txt");
DivideByZeroException ex_int = new DivideByZeroException();
x.LogInfo("Var Int");
x.LogWarning("Warnig Int");
x.LogError("Error Int", ex_int);

//Тип string
LocalFileLogger<string> str = new LocalFileLogger<string>("C:/Users/Vasiliy/source/repos/For_Bars/ForBars_2/Test.txt");
FormatException ex_str = new FormatException();
str.LogInfo("Var String");
str.LogWarning("Warning String");
str.LogError("Error String", ex_str);

//Тип bool
LocalFileLogger<bool> var_bool = new LocalFileLogger<bool>("C:/Users/Vasiliy/source/repos/For_Bars/ForBars_2/Test.txt");
NotSupportedException ex_bool = new NotSupportedException();
var_bool.LogInfo("Var Bool");
var_bool.LogWarning("Warning Bool");
var_bool.LogError("Error Bool", ex_bool);

//Тип float
LocalFileLogger<float> var_float = new LocalFileLogger<float>("C:/Users/Vasiliy/source/repos/For_Bars/ForBars_2/Test.txt");
ArgumentException ex_float = new ArgumentException();
var_float.LogInfo("Var Float");
var_float.LogWarning("Warning Float");
var_float.LogError("Error Float", ex_float);

//Тип object
LocalFileLogger<object> var_object = new LocalFileLogger<object>("C:/Users/Vasiliy/source/repos/For_Bars/ForBars_2/Test.txt");
TimeoutException ex_object = new TimeoutException();
var_object.LogInfo("Var Object");
var_object.LogWarning("Warning Object");
var_object.LogError("Error Object", ex_object);



public interface ILogger{
    public void LogInfo(string message);
    public void LogWarning(string message);
    public void LogError(string message, Exception ex);
}

public class LocalFileLogger<T>:ILogger
{
    private string file_path;
    public LocalFileLogger(string file_path)
    {
        this.file_path = file_path;
    }
    public async void LogInfo(string message)
    {
        string log_info = $"[Info]: [{typeof(T).Name}] : {message}";
        using (StreamWriter writer = new StreamWriter(file_path, true))
        {
            await writer.WriteLineAsync(log_info);
        }
    }
    public async void LogWarning(string message)
    {
        string log_warning = $"[Warning] : [{typeof(T).Name}] : {message}";
        using (StreamWriter writer = new StreamWriter(file_path, true))
        {
            await writer.WriteLineAsync(log_warning);
        }
    }
    public async void LogError(string message, Exception ex)
    {
        string log_error = $"[Error] : [{typeof(T).Name}] : {message}. {ex.Message}";
        using (StreamWriter writer = new StreamWriter(file_path, true))
        {
            await writer.WriteLineAsync(log_error);
        }
    }

}

