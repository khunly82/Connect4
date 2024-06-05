namespace Connect4.API.BusinessObjects
{
    public class TableBO
    {
        public string Name { get; set; } = null!;
        public string? RedPlayer { get; set; }
        public string YellowPlayer { get; set; } = null!;
        public Connect4BO Grid { get; set; } = new Connect4BO();
    }
}
