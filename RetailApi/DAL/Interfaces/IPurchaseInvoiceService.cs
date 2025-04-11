using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IPurchaseInvoiceService
    {
        public List<PIDropdownData> GetPendingPoList(PIDropdownInput input);
        public GRNDetailResponce GetSelectedPoDetailS(GRNDetailInput input);
        public Int32 Insert(PurchHeader purchHeader);
        public Int32 Update(PurchHeader purchHeader);
    }
}
