using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IDepartmentService
    {
        public List<Department> GetAllDepartments();
        public int SaveDepartment(Department department);
        public Department GetDepartmentById(int id);
        public bool DeleteDepartment(int id);
    }
}
