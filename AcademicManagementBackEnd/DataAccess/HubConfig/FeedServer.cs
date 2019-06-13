using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HubConfig
{
    public class FeedServer : Hub
    {
        public async Task NewPost()
        {
            await Clients.All.SendAsync("post");
        }

    }
}
