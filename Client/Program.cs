using System.Net;
using System.Net.Sockets;

namespace Client;

class Program
{
    static async Task Main()
    {
        var ipAddress = (await Dns.GetHostEntryAsync("localhost")).AddressList[0];
        var client = new Client(ipAddress);
        
        await client.Connect(80);
        await client.SendDataAsync("capybaraluv");
        client.CloseConnection();
        
        await client.Connect(80);
        await client.SendDataAsync("orange");
        client.CloseConnection();
        
        await client.Connect(90);
        await client.SendDataAsync("muavyshka");
    }
}