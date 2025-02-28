using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface ITransferOutService
    {
        public List<ItemDetails> GetItems(InputStore input);
        public Int32 Insert(TransferOut transferOut);
        public Int32 Update(TransferOut transferOut);
        public Int32 Verify(TransferOut transferOut);
        public Int32 Approve(TransferOut transferOut);
        public bool Delete(int id);
        public List<TransferOut> List(Int32 intUserID);
        public TransferOut GetTransferOut(int id);
    }
}
 