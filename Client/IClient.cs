namespace Client;

public interface IClient
{
    public Task Connect(int port);

    public Task SendDataAsync(string message);

    public void CloseConnection();
}