using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IEmployeeDepartmentService
    {
        public List<EmployeeDepartment> GetAllDepartment();
        public Int32 SaveData(EmployeeDepartment company);
        public EmployeeDepartment GetItems(int id);
        public bool DeleteDepartment(int id);
    }
}
