namespace Notification
{
    public class TableReference
    {
        public TableReference(string tableName)
        {
            TableName = tableName;
        }

        public string TableName { get; }
    }
}