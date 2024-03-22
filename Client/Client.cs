using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client;

public sealed class Client : IClient
{
    public IPAddress IpAddress { get; private set; } 
    
    public IPEndPoint? EndPoint { get; private set; }
    
    public Socket? Sender { get; private set; }
    
    
    public Client(IPAddress ipAddress)
    {
        IpAddress = ipAddress;
    }
    
    public async Task Connect(int port)
    {
       /* IpAddress = Dns.GetHostEntry("localhost").AddressList[0];
        EndPoint = new IPEndPoint(IpAddress, port);
        Console.WriteLine("endpoint created");*/
       EndPoint = new IPEndPoint(IpAddress, port);
       Sender  = new Socket(IpAddress.AddressFamily,
           SocketType.Stream, ProtocolType.Tcp);
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
            Console.WriteLine($"has successfully connected to {Sender.RemoteEndPoint}");

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
        Sender.Close();
        Console.WriteLine("Client connection closed");
    }
}