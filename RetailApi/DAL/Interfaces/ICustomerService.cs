using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface ICustomerService
    {
        public List<Customer> GetAllCustomers();
        public Int32 SaveData(Customer company);
        public Customer GetItems(int id);
        public bool DeleteCustomers(int id);
    }
}
