using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IDropDownService
    {
        public List<DropDown> GetDropDownData(string vname);
    }
}
