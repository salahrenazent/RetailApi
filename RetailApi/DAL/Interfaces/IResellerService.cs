using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IResellerService
    {
        public List<Reseller> GetAllReseller();
        public Int32 Insert(Reseller reseller);
        public Reseller GetItems(int id);
        public bool Update(Reseller reseller);
        public bool DeleteReseller(int id);
    }
}
