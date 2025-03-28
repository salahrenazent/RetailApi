using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface ISalaryHeadService
    {
        public List<SalaryHead> GetAllSalaryHead();
        public Int32 SaveData(SalaryHead salaryHead);
        public Int32 EditData(SalaryHead salaryHead);
        public SalaryHead GetItem(int id);
        public bool DeleteSalaryHead(int id);
    }
}
