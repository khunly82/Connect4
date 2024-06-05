using Connect4.API.BusinessObjects;
using Connect4.API.DTO;
using Connect4.API.Services;
using Microsoft.AspNetCore.SignalR;

namespace Connect4.API.Hubs
{
    public class GameHub(TableService tableService) : Hub
    {
        public void Create(string name)
        {
            TableBO table = tableService.CreateTable(name);
            Groups.AddToGroupAsync(Context.ConnectionId, table.Name);
            Clients.All.SendAsync("AllTables", tableService.Tables.Select(t => new TableDTO(t)));
            Clients.Group(table.Name).SendAsync("CurrentGame", new TableDetailledDTO(table));
        }

        public void Join(JoinTableDTO dto)
        {
            TableBO table = tableService.Join(dto.TableName, dto.PlayerName);
            Groups.AddToGroupAsync(Context.ConnectionId, table.Name);
            Clients.All.SendAsync("AllTables", tableService.Tables.Select(t => new TableDTO(t)));
            Clients.Group(table.Name).SendAsync("CurrentGame", new TableDetailledDTO(table));
        }

        public void Play(PlayDTO dto)
        {
            TableBO table = tableService.GetByName(dto.TableName);
            table.Grid.Play(dto.Col);
            Clients.Group(table.Name).SendAsync("CurrentGame", new TableDetailledDTO(table));
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("AllTables", tableService.Tables.Select(t => new TableDTO(t)));
        }
    }
}
