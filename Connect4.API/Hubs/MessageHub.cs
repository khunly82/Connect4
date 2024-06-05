using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Connect4.API.Hubs
{
    public class MessageHub : Hub
    {
        public void SendMessage(string message)
        {
            Clients.All.SendAsync("message", message);
        }

        public override Task OnConnectedAsync()
        {
            // envoyer à la personne qui vient de se connecter
            Clients.Caller.SendAsync("info", "Vous êtes bien connecté");

            // envoyer à tous les autres
            Clients.Others.SendAsync("info", "Un autre utilisateur  s'est connecté");

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
