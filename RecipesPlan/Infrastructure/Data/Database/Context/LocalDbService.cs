using RecipesPlan.Infrastructure.Data.Database.Model;
using SQLite;

namespace RecipesPlan.Infrastructure.Data.Database.Context
{
    public class LocalDbService : ILocalDbService
    {
        private const string DB_NAME = "localdb.db";
        private readonly SQLiteAsyncConnection _connection;
        public SQLiteAsyncConnection Connection => _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Recipe>();
            _connection.CreateTableAsync<Ingredient>();
            _connection.CreateTableAsync<Menu>();
        }

    }
}
