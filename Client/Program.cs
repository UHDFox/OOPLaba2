namespace Client;

class Program
{
    static async Task Main()
    {
        var client = new Client();
        await client.Connect(80);
        await client.SendDataAsync("capybaraluv");
        await client.SendDataAsync("orange");
        client.CloseConnection();
    }
}