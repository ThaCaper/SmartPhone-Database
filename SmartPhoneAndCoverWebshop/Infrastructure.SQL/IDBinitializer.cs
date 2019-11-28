namespace Infrastructure.SQL
{
    public interface IDBinitializer
    {
        void Initialize(DatabaseContext context);
    }
}