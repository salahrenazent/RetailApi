using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IPackingService
    {
        public List<Packing> GetAllPacking();
        public bool Insert(Packing packing);
        public Packing GetItems(int id);
        public bool Update(Packing packing);
        public bool DeletePacking(int id);
    }
}
