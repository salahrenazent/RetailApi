using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IItemSubCategoryService
    {
        public List<ItemSubCategory> GetAllItemSubCategory();
        public Int32 SaveData(ItemSubCategory company);
        public ItemSubCategory GetItems(int id);
        public bool DeleteItemSubCategory(int id);
    }
}
