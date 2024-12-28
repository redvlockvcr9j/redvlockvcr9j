namespace Masa.Contrib.Dispatcher.IntegrationEvents.Dapr.Tests.Events;

public record RegisterUserIntegrationEvent : IntegrationEvent
{
    public string Account { get; set; }

    public string Password { get; set; }

    public override string Topic { get; set; } = nameof(RegisterUserIntegrationEvent);
}
