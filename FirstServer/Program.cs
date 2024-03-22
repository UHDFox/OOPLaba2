namespace FirstServer;

class Program
{
    static async Task Main()
    {
        var listener = new FirstServer();
        await listener.BindListenerAsync();
        await listener.ListenAsync();

    }
}