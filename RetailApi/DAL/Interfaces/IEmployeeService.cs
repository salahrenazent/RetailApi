using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employee> GetAllEmployees();
        public Int32 SaveData(Employee company);
        public Employee GetItems(int id);
        public bool DeleteEmployees(int id);
    }
}
