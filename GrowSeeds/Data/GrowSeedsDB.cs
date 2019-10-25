using GrowSeeds.Models;
using SQLite;
using System.Threading.Tasks;

namespace GrowSeeds.Data
{
    public class GrowSeedsDB
    {
        readonly SQLiteAsyncConnection database;

        public GrowSeedsDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Plant>().Wait();
        }

        public Task<int> SaveItemAsync(Plant item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Plant item)
        {
            return database.DeleteAsync(item);
        }
    }
}
