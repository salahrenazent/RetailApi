using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface ITransferInService
    {
        public List<TransferList> GetItems(StoreInput input);
        public List<TransferOutList> GetData(TransferOutInput input);
        public Int32 Insert(TransferIn transfeIn);
        public Int32 Update(TransferIn transfeIn);
        public Int32 Verify(TransferIn transfeIn);
        public bool Delete(int id);
    }
}
