using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IImportTemplateColoumnService
    {
        public List<ImportTemplateColoumns> GetAllTemplateColoumns(Int32 intUserID);
    }
}
