using GrowSeeds.Models;
using SQLite;
using System.Collections.Generic;
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

        public Task<int> SavePlantAsync(Plant item)
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

        public Task<int> DeletePlantAsync(Plant item)
        {
            return database.DeleteAsync(item);
        }

        public Task<List<Plant>> GetPlantAsync()
        {
            return database.Table<Plant>().ToListAsync();
        }
    }
}
