using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IImportItemInsertService
    {
        public bool Insert(List<InsertImportItem> insertImportItems);
    }
}
