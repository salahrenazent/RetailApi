using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface ISupplierService
    {
        public List<Supplier> GetAllSuppliers();
        public bool SaveData(Supplier supplier);
        public Supplier GetItems(int id);
        public bool DeleteSupplier(int id);
    }
}
