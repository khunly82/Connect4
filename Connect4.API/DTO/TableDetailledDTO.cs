using Connect4.API.BusinessObjects;

namespace Connect4.API.DTO
{
    public class TableDetailledDTO : TableDTO
    {
        public Color[][] Grid { get; set; } = new Color[6][];
        public TableDetailledDTO(TableBO table) : base(table)
        {
            for (int y = 0; y < table.Grid.Grid.GetLength(1); y++)
            {
                Color[] ligne = new Color[7];
                Grid[y] = ligne;
                for(int x = 0; x < table.Grid.Grid.GetLength(0); x++)
                {
                    ligne[x] = table.Grid.Grid[x, y];
                }
            }
        }
    }
}
