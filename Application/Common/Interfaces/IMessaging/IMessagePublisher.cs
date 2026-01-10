namespace Application.Common.Interfaces.IMessaging
{
    public interface IMessagePublisher
    {
        Task PublishAsync(string message, string routingKey);
    }
}
