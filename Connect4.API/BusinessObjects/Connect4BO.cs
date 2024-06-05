namespace Connect4.API.BusinessObjects
{
    public class Connect4BO
    {
        private Color[,] _grid = new Color[7,6];

        public Color Turn { get; private set; } = Color.Yellow;

        public void Play(int col)
        {
            int? row = FindRow(col);
            if (row == null)
            {
                throw new Exception("This column is full");
            }
            _grid[col, (int)row] = Turn;
            Turn = Turn == Color.Red ? Color.Yellow : Color.Red;
            // Turn = (Color)(((int)Turn) * - 1);
        }

        //private bool CheckColumn(int col)
        //{
        //    return _grid[col, 5] == Color.None;
        //}

        private int? FindRow(int col)
        {
            return Enumerable
                .Range(0, 6)
                .FirstOrDefault(y => _grid[col, y] == Color.None);
            //for(int y = 0; y < 6; y++)
            //{
            //    if(_grid[col, y] == Color.None)
            //    {
            //        return y;
            //    }
            //}
            //return null;
        }
    }
}
