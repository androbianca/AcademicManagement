using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BusinessLogic.HubConfig
{

    public class NotificationsServer : Hub
    {
        public async Task NewMessage()
        {
            await Clients.All.SendAsync("message");
        }

    }
}
