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
            tableService.CreateTable(name);
            Clients.All.SendAsync("AllTables", tableService.Tables.Select(t => new TableDTO(t)));
        }

        public void Join(JoinTableDTO dto)
        {
            tableService.Join(dto.TableName, dto.PlayerName);
            Clients.All.SendAsync("AllTables", tableService.Tables.Select(t => new TableDTO(t)));
        }

        public void Play(PlayDTO dto)
        {
            TableBO table = tableService.GetByName(dto.TableName);
            table.Grid.Play(dto.Col);
        }
    }
}
