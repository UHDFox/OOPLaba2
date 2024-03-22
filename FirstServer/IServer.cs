namespace FirstServer;

public interface IServer
{
    public Task BindListenerAsync();

    public Task ListenAsync();

    public void PrintMessage(string message);
    public void CloseConnection();
}