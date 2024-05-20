using System.Net;


namespace Client;

class Program
{
    static async Task Main()
    {
        var ipAddress = (await Dns.GetHostEntryAsync("localhost")).AddressList[0];
      

        var client = new Client(ipAddress, 80);
    
        await client.Connect(80);
        await client.SendDataAsync("message 1"); 
        await client.SendDataAsync("message 2");
        await client.SendDataAsync("message 3 da");
        client.CloseConnection();


        client = new Client(ipAddress, 90);
        await client.Connect(90);
        await client.SendDataAsync("server 2 m1"); 
        await client.SendDataAsync("test test teste"); 
        await client.SendDataAsync("ya hochu spat'"); 
        await client.SendDataAsync("cl"); 
        client.CloseConnection();

    }
}