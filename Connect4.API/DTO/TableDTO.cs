using Connect4.API.BusinessObjects;

namespace Connect4.API.DTO
{
    public class TableDTO
    {
        public TableDTO(TableBO table)
        {
            Name = table.Name;
            RedPlayer = table.RedPlayer;
            YellowPlayer = table.YellowPlayer;
        }

        public string Name { get; set; } = null!;
        public string? RedPlayer { get; set; }
        public string YellowPlayer { get; set; } = null!;
    }
}
