using System.Net;
using System.Net.Sockets;
using System.Text;

namespace OOPLaba2;

public sealed class Client : IClient
{
    public string Message { get; set; }

    public Client(string message)
    {
        Message = message;
    }

    public async Task SendData()
    {
        var ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
        var sender = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);

        var endPoint = new IPEndPoint(ipAddress, 80);
        Console.WriteLine("endpoint created");
        try
        {
            await sender.ConnectAsync(endPoint);
            Console.WriteLine($"has successfully connected to {sender.RemoteEndPoint}");

            byte[] message = Encoding.ASCII.GetBytes("CapybaraTest");
            await sender.SendAsync(message);
        }
        catch (Exception e)
        {
            Console.WriteLine($"everythin's bad{e.Message}");
        }

    }
}