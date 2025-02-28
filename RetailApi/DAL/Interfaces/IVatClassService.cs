using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IVatClassService
    {
        public List<VatClass> GetAllVatClass();
        public Int32 SaveData(VatClass company);
        public VatClass GetItems(int id);
        public bool DeleteVatClass(int id);
    }
}
