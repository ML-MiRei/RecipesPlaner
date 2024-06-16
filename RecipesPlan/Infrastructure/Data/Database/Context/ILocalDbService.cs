using SQLite;

namespace RecipesPlan.Infrastructure.Data.Database.Context
{
    public interface ILocalDbService
    {
        public SQLiteAsyncConnection Connection { get; }
    }
}
