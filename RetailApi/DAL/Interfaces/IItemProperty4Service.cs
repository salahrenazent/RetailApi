using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IItemProperty4Service
    {
        public List<ItemProperty4> GetAllItemProperty4();
        public Int32 SaveData(ItemProperty4 company);
        public ItemProperty4 GetItems(int id);
        public bool DeleteItemProperty4(int id);
    }
}
