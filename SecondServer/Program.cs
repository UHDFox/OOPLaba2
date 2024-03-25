using System.Net;
using System.Net.Sockets;

namespace SecondServer;

class Program
{
    static async Task Main()
    {
        var ipAddress = (await Dns.GetHostEntryAsync("localhost")).AddressList[0];
        
        var endPoint = new IPEndPoint(ipAddress, 90);

        var socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        
        var server = new SecondServer(ipAddress, endPoint, socket);
        server.BindListener();
        await server.ListenAsync();
        server.CloseConnection();
    }
}