using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IItemBrandService
    {
        public List<ItemBrand> GetAllItemBrand(Int32 intUserID);
        public Int32 SaveData(ItemBrand itembrand, Int32 userID);
        public List<ItemBrand> GetItems(int id);
        public bool DeleteItemBrand(int id, int userID);
    }
}
