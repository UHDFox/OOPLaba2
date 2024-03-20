namespace ServerOne;

class Program
{
    static async Task Main()
    {
        var listener = new Server();
            var res = await listener.BindListener();
    }
}