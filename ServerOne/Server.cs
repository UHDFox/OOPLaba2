using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerOne;

public sealed class Server : IServer
{
    public async Task<string> BindListener()
    {
        string result;
        var ipAddress = (await Dns.GetHostEntryAsync("localhost")).AddressList[0];
        var endPoint = new IPEndPoint(ipAddress, 80);
        Socket listener = new(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        listener.Bind(endPoint);
        Console.WriteLine("Server's up");
        listener.Listen();
        Console.WriteLine("server's listening");

        while (true)
        {
            var handler = await listener.AcceptAsync();
            var buffer = new byte[1024];
            var receivedMessage = await handler.ReceiveAsync(buffer);
            var message = Encoding.UTF8.GetString(buffer,0, receivedMessage);
            Console.WriteLine($"Message received:\n {message}");
            result = message;
            break;
        }

        return result;
    }
}