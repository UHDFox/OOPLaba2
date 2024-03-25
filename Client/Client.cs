using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client;

public sealed class Client : IClient
{
    public IPAddress IpAddress { get; set; } 
    
    public IPEndPoint EndPoint { get; set; }
    
    public Socket Sender { get; set; }
    
    
    public Client(IPAddress ipAddress,int port)
    {
        IpAddress = ipAddress;
        EndPoint = new IPEndPoint(ipAddress, port);
        Sender = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    }
    
    
    public async Task Connect(int port)
    {
        IpAddress = Dns.GetHostEntry("localhost").AddressList[0];
        EndPoint = new IPEndPoint(IpAddress, port);
        Sender = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            await Sender.ConnectAsync(EndPoint);
            Console.WriteLine("Connected to port");
        }
        catch (Exception e)
        {
            Console.WriteLine($"couldn't connect to server - {e}");
        }
        
    }

    public async Task SendDataAsync(string message)
    {
        try
        {
            Console.WriteLine($"has successfully sent message to {Sender.RemoteEndPoint}");

            byte[] encodedMessage = Encoding.ASCII.GetBytes(message);
            await Sender.SendAsync(encodedMessage);
        }
        catch (Exception e)
        {
            Console.WriteLine($"everythin's bad - {e.Message}");
        }
    }

    public void CloseConnection()
    {
        Sender.Dispose();
        Console.WriteLine("Client connection closed");
    }
}