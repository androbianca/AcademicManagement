using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BusinessLogic.HubConfig
{

    public class NotificationsServer : Hub
    {
        public async Task NewNotification()
        {
            await Clients.All.SendAsync("notification");
        }

    }
}
