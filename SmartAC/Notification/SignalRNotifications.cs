using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SmartAC.Notification
{
    public class ChatHub : Hub<ITypedNotificationHub>
    {
        public void Send(string name, string message)
        {
            Clients.All.BroadcastMessage(name, message);
        }
    }
}