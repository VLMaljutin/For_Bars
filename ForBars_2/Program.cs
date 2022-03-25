// Задание 1 - обобщение 
Exception ex = new Exception();
// Тип int
LocalFileLogger<int> x = new LocalFileLogger<int>("C:/Users/Vasiliy/source/repos/For_Bars/ForBars_2/Test.txt");
x.LogInfo("Var Int");
x.LogWarning("Var Int");
x.LogError("Var Int", ex);

//Тип 

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

