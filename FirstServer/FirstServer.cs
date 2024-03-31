using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FirstServer;

public sealed class FirstServer : IServer
{
    public IPAddress IpAddress { get; private set; } 
    
    private IPEndPoint IpEndPoint { get; set; }
    
    private Socket Listener {  get; set; }
    
    public FirstServer(IPAddress ipAddress, IPEndPoint ipEndPoint, Socket listener)
    {
        IpAddress = ipAddress;
        IpEndPoint = ipEndPoint;
        Listener = listener;
    }
    public void BindListener() //method that binds server to some local point
    {
        Listener.Bind(IpEndPoint);
        Console.WriteLine("Server's up");
    }

    public async Task ListenAsync() //method that listens to incoming requests
    {
        Listener.Listen(); 
        Console.WriteLine("now i'm listening");

        while(true)
        {
            var handler = await Listener.AcceptAsync(); // create new socket to handle incoming connection
            var buffer = new byte[1024]; //buffer array. we'll put received message in there
            var builder = new StringBuilder();
            int count;
            do
            {
                count = await handler.ReceiveAsync(buffer);
                string message = Encoding.UTF8.GetString(buffer, 0, count); //decode received message 
                buffer = new byte[1024];
                builder.Append("\n" + (message));
            } 
            
            while (count > 0);
            {
                PrintMessage(builder.ToString());
            }
            
        }
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine($"Server one have received a message!");
        Console.WriteLine($"Received message: {message}");
    }

    public void CloseConnection()
    {
        Listener.Dispose();
        Console.WriteLine("Socket closed");
    }
}