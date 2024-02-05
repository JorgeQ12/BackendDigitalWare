using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;

namespace GamblingBackDW.SocketSignalR
{
    [EnableCors("CorsPolicy")]
    public class SocketMessage : Hub
    {
        IHubContext<SocketMessage> _socketMessage;
        public SocketMessage(IHubContext<SocketMessage> socketMessage)
        {
            _socketMessage = socketMessage;
        }

        public async Task SendMessage(string user, string message, string idChange)
        {
           await _socketMessage.Clients.All.SendAsync("Resive Mensaje",  user, message, idChange );
        }
    }
}
