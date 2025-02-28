using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IDeliveryTermsService
    {
        public List<DeliveryTerms> GetAllDeliveryTerms();
        public Int32 SaveData(DeliveryTerms company);
        public DeliveryTerms GetItems(int id);
        public bool DeleteDeliveryTerms(int id);
    }
}
