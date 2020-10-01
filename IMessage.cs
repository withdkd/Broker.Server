namespace Broker.Server
{
    public interface IMessage
    {
        int ThemeCode { get; set; }
        string PostedMessage { get; set; }
    }
}