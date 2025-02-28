using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IReportTemplateService
    {
        public List<ReportTemplate> GetReportTemplates();
        public Int32 CheckDefault(ReportInput input);
        public List<ReportOutput> GetReportOutput(ReportInput input);
        public List<ReportTemplate> GetTemplateList(ReportInput input);
    }
}
