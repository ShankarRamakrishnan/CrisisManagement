namespace Chat
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR;

    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            try
            {
                Clients.All.Send(message);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public async Task JoinRoom(string roomName)
        {
            await Groups.Add(Context.ConnectionId, roomName);
            Clients.Group(roomName).addChatMessage(Context.User.Identity.Name + " joined.");
        }

        public Task LeaveRoom(string roomName)
        {
            return Groups.Remove(Context.ConnectionId, roomName);
        }
    }
}
