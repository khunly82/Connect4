using Connect4.API.BusinessObjects;
using Connect4.API.DTO;
using Connect4.API.Services;
using Microsoft.AspNetCore.SignalR;

namespace Connect4.API.Hubs
{
    public class GameHub(TableService tableService) : Hub
    {
        public async void Create(string name)
        {
            TableBO table = tableService.CreateTable(name);
            await Groups.AddToGroupAsync(Context.ConnectionId, table.Name);
            await Clients.All.SendAsync("AllTables", tableService.Tables.Select(t => new TableDTO(t)));
            await Clients.Group(table.Name).SendAsync("CurrentGame", new TableDetailledDTO(table));
        }

        public async void Join(JoinTableDTO dto)
        {
            TableBO table = tableService.Join(dto.TableName, dto.PlayerName);
            await Groups.AddToGroupAsync(Context.ConnectionId, table.Name);
            await Clients.All.SendAsync("AllTables", tableService.Tables.Select(t => new TableDTO(t)));
            await Clients.Group(table.Name).SendAsync("CurrentGame", new TableDetailledDTO(table));
        }

        public async void Play(PlayDTO dto)
        {
            TableBO table = tableService.GetByName(dto.TableName);
            table.Grid.Play(dto.Col);
            await Clients.Group(table.Name).SendAsync("CurrentGame", new TableDetailledDTO(table));
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("AllTables", tableService.Tables.Select(t => new TableDTO(t)));
        }
    }
}
