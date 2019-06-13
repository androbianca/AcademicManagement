using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace DataAccess.HubConfig
{
    public class AlertServer : Hub
    {
        public async Task NewAlert()
        {
            await Clients.All.SendAsync("alert");
        }

    }

}
