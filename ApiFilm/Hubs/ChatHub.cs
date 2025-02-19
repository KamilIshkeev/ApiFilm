using Microsoft.AspNetCore.SignalR;

namespace ApiFilm.Hubs
{
    public class ChatHub : Hub
    {
        private static Dictionary<string, string> Users = new();

        public override Task OnConnectedAsync() 
        {
            return base.OnConnectedAsync();
        }

        public async Task RegisterUser(string username)
        {
            Users[username] = Context.ConnectionId;


        }

        public async Task SendMessage(string recipient, string user, string message)
        {
            if (Users.TryGetValue(recipient, out var connectionId))
            { 
                  await Clients.Client(connectionId).SendAsync("ReceiveMessage", user, message);
            }
            

        }

    }
}
