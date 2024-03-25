namespace SecondServer;

public interface IServer
{
    public void BindListener();

    public Task ListenAsync();

    public void PrintMessage(string message);
    
    public void CloseConnection();
}