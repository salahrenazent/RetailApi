using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IItemProperty1Service
    {
        public List<ItemProperty1> GetAllItemProperty1();
        public Int32 SaveData(ItemProperty1 company);
        public ItemProperty1 GetItems(int id);
        public bool DeleteItemProperty1(int id);
    }
}
