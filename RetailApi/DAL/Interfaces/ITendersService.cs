using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface ITendersService
    {
        public List<Tenders> GetAllTender();
        public Int32 SaveData(Tenders company);
        public Tenders GetItems(int id);
        public bool DeleteTenders(int id);
    }
}
