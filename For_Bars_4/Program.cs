string? com = "";
string? message = "";
List<string> arguments = new List<string>();
while (com != "/exit")
{
    Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");
    com = Console.ReadLine();

    if (com == "/exit")
    {
        break;
    }
    else
    {
        Console.WriteLine("Введите аргументы сообщения. Если аргументы не нужны нажмите enter");
        message = com;
        com = Console.ReadLine();
        while (com != "")
        {
            arguments.Add(com);
            Console.WriteLine("Введите следующий аргумент сообщения. Если аргументы не нужны нажмите enter");
            com = Console.ReadLine();
        }
    }
    ThreadPool.QueueUserWorkItem(callBack => HandleRequest(message, arguments.ToArray()));

    arguments = new List<string>();
}

Console.WriteLine("Приложение завершает работу");

static void HandleRequest(string message, string[] args)
{
    string messageID = Guid.NewGuid().ToString("D");
    DummyRequestHandler Handler = new DummyRequestHandler();

    Console.WriteLine($"Было отправлено сообщение {message}. Присвоен индентефикатор {messageID}");
    try
    {
        Console.WriteLine($"Сообщение с индентификатором {messageID} получило ответ {Handler.HandleRequest(message, args)}");
    }
    catch (Exception e)
    {
        Console.WriteLine($"Сообщение с индентификатором {messageID} упало с ошибкой {e.Message}");
    }

}

public interface IRequestHandler
{
    /// <summary>
    /// Обработать запрос.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <param name="arguments">Аргументы запроса.</param>
    /// <returns>Результат выполнения запроса.</returns>
    string HandleRequest(string message, string[] arguments);
}

public class DummyRequestHandler : IRequestHandler
{
    /// <inheritdoc />
    public string HandleRequest(string message, string[] arguments)
    {
        // Притворяемся, что делаем что то.
        Thread.Sleep(10_000);
        if (message.Contains("упади"))
        {
            throw new Exception("Я упал, как сам просил");
        }
        return Guid.NewGuid().ToString("D");
    }
}



