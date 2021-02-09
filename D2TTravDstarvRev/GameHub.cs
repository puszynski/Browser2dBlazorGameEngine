using GameLibrary.GameModels;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace D2TTravDstarvRev
{
    // https://docs.microsoft.com/pl-pl/azure/azure-signalr/signalr-tutorial-build-blazor-server-chat-app
    public class GameHub : Hub
    {
        public const string HubUrl = "/game";

        public async Task Broadcast(string playerID, string playerObjectJSON)
        {
            await Clients.All.SendAsync("Broadcast", playerID, playerObjectJSON);//todo tests it
        }



        #region ChatMsg
        public async Task BroadcastChatMsg(string username, string message)
        {
            await Clients.All.SendAsync("BroadcastChatMsg", username, message); //spr NAJPIERW czy to dziala (po zmianie nazw)
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }
        #endregion
    }
}
