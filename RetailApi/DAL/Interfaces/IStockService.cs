using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IStockService
    {
        public StockResponse GetStockWithStore(StockInput input);
    }
}
