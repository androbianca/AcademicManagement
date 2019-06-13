using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HubConfig
{
    public class CommentServer : Hub
    {
        public async Task NewComment()
        {
            await Clients.All.SendAsync("comment");
        }

    }
}
