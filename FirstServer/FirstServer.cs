using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FirstServer;

public sealed class FirstServer : IServer
{
    public IPAddress IpAddress { get; private set; } 
    
    public IPEndPoint IpEndPoint { get; private set; }
    
    public Socket Listener { get; private set; }
    
    public FirstServer(IPAddress ipAddress, IPEndPoint ipEndPoint, Socket listener)
    {
        IpAddress = ipAddress;
        IpEndPoint = ipEndPoint;
        Listener = listener;
    }
    public async Task BindListenerAsync() //method that binds server to some local point
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
            var receivedMessage = await handler.ReceiveAsync(buffer);//we receive message as byte array
            string message = Encoding.UTF8.GetString(buffer,0, receivedMessage); //decode received message  
            Console.WriteLine($"Server one have received a message!");
            PrintMessage(message);
        }
       
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine($"Received message: {message}");
    }

    public void CloseConnection()
    {
        Listener.Close();
        Console.WriteLine("Socket closed");
    }
}