using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IStoresService
    {
        public List<Stores> GetAllStores();
        public Int32 SaveData(Stores company);
        public Stores GetItems(int id);
        public bool DeleteStores(int id);
    }
}
