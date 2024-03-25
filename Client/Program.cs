using System.Net;
using System.Net.Sockets;

namespace Client;

class Program
{
    static async Task Main()
    {
        var ipAddress = (await Dns.GetHostEntryAsync("localhost")).AddressList[0];
      

        var client = new Client(ipAddress, 80);
    
        await client.Connect(80);
        await client.SendDataAsync("capybaraluv"); 
        await client.SendDataAsync("orange");
        client.CloseConnection();


        client = new Client(ipAddress, 90);
        await client.Connect(90);
        await client.SendDataAsync("muavyshka"); 
        await client.SendDataAsync("bambuuu"); 
        client.CloseConnection();

    }
}