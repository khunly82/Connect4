using Connect4.API.BusinessObjects;

namespace Connect4.API.DTO
{
    public class PlayDTO
    {
        public string PlayerName { get; set; } = null!;
        public string TableName { get; set; } = null!;
        public int Col { get; set; }
    }
}
