using System.Threading.Tasks;

namespace GrowSeeds.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
    }
}
