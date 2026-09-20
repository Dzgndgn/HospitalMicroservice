using Microsoft.AspNetCore.SignalR; 

namespace Doccure.QueueService.Hubs
{
    public class QueueHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
