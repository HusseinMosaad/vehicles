using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Linq;

namespace WebApplication
{
    
    public class VLogHub : Hub
    {
       

        public async Task broadcastMessage(string nick, string message)
        {
            try
            {
                await Clients.All.SendAsync("ReceiveMessage", nick, message);
                //await Clients.All.InvokeAsync("Send", nick, message);
            }
            catch (Exception ex)
            {
            }



        }

        

 
       
    }
}
