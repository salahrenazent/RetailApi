using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IUomService
    {
        public List<Uom> GetAllUom();
        public bool Insert(Uom uom);
        public Uom GetItems(int id);
        public bool Update(Uom uom);
        public bool DeleteUom(int id);
    }
}
