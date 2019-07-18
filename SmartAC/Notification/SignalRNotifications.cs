using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SmartAC.Notification
{
    public class ChatHub : Hub<ITypedNotificationHub>
    {
        public void Send(string deviceId, string sensorId,string message)
        {
            Clients.All.BroadcastMessage(deviceId, sensorId, message);
        }
    }
}