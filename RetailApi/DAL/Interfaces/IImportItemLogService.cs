using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IImportItemLogService
    {
        public List<ImportItemLog> GetAllItemLog();
        public List<InsertImportItemLogEntry> GetAllItemLogEntry(ImportItemLog itemLog);
        public bool Insert(ImportItemLog importItemLog);
    }
}
