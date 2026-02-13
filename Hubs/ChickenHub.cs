using Microsoft.AspNetCore.SignalR;

namespace ChickenSystem.Hubs;

public class ChickenHub:Hub
{
    private readonly ILogger<ChickenHub> _logger;
    public ChickenHub(ILogger<ChickenHub> logger)
    {
        _logger = logger;
    }
    public override Task OnConnectedAsync()
    {
        _logger.LogInformation($"Hub connected: {Context.ConnectionId}");
        return base.OnConnectedAsync();
    }
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation($"Hub disconnected: {Context.ConnectionId}");
        return base.OnDisconnectedAsync(exception);
    }
}