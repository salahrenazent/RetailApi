using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface ICompanyService
    {
        public List<Company> GetAllCompany();
        public Int32 SaveData(Company company);
        public Company GetItems(int id);
        public bool DeleteCompany(int id);
        public List<DocSettings> GetAllDocSettings();

    }
}
