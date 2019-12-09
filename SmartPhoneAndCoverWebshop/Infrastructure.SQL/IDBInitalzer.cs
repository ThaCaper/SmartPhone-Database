namespace Infrastructure.SQL
{
    public interface IDBInitalzer
    {
        void Initialize(DatabaseContext context);
    }
}