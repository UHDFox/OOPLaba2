namespace ServerOne;

public interface IServer
{
    public Task<string> BindListener();
}