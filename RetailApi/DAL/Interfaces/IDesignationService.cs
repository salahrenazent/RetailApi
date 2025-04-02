using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IDesignationService
    {
        public List<Designation> GetAllDesignations();
        public int SaveDesignation(Designation designation);
        public Designation GetDesignationById(int id);
        public bool DeleteDesignation(int id);
    }
}
