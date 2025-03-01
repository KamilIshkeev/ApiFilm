﻿using Microsoft.AspNetCore.SignalR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiFilm.Hubs
{
    public class ChatHub : Hub
    {
        private static Dictionary<string, string> Users = new();

        public override Task OnConnectedAsync() 
        {
            return base.OnConnectedAsync();
        }

        //public async Task RegisterUser(string username)
        //{
        //    Users[username] = Context.ConnectionId;


        //}
/*string recipient,*/
        public async Task SendMessage(string user, string message, string movie)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, movie);

            //if (Users.TryGetValue(recipient, out var connectionId))
            //{
            //await Clients.Client(connectionId).SendAsync("ReceiveMessage", user, message);
            //}


        }

        //public async Task SendMessage(string recipient, string user, string message, string movName)
        //{
        //    if (Users.TryGetValue(recipient, out var connectionId))
        //    { 
        //          await Clients.Client(connectionId).SendAsync("ReceiveMessage", user, message, movName);
        //    }


        //}

        //public async Task SendMessageMov(string user, string message, int? movieId)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage1", user, message, movieId);
        //}

        //// Отправка фото всем пользователям
        //public async Task SendPhoto(string user, string filePath, int messageId)
        //{
        //    await Clients.All.SendAsync("ReceivePhoto", user, filePath, messageId);
        //}

    }
}
