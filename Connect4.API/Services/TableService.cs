using Connect4.API.BusinessObjects;

namespace Connect4.API.Services
{
    public class TableService
    {
        public List<TableBO> Tables { get; } = [];
        public TableBO CreateTable(string player)
        {
            TableBO table = new TableBO();
            table.Name = Guid.NewGuid().ToString();
            table.YellowPlayer = player;
            return table;
        }

        public TableBO Join(string tableName, string player)
        {
            TableBO table = GetByName(tableName);

            if(table.RedPlayer != null)
            {
                throw new Exception("Table is full");
            }

            table.RedPlayer = player;
            return table;
        }

        public TableBO GetByName(string tableName)
        {
            TableBO? table = Tables.Find(t => t.Name == tableName);
            if (table == null)
            {
                throw new Exception("Table not found");
            }
            return table;
        }
    }
}
