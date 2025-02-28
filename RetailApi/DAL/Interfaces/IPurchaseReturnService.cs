using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IPurchaseReturnService
    {
        public List<GRN_List> GetGrn(Input input);
        public List<GRN_DATA> GetGrnDetails(GrnInput input);
        public Int32 Insert(PurchaseReturn purchaseReturn);
        public Int32 Update(PurchaseReturn purchaseReturn);
        public PurchaseReturn GetPurchaseReturn(int id);
        public List<PurchaseReturn> List();
        public bool Delete(int id);
        public Int32 Verify(PurchaseReturn purchaseReturn);
        public Int32 Approve(PurchaseReturn purchaseReturn);
    }
}
