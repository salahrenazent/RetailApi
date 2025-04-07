using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IEOSService
    {
        public List<EosReason> GetAllEosReasons();
        public int SaveEosReason(EosReason eosReason);
        public EosReason GetEosReasonById(int id);
        public bool DeleteEosReason(int id);
    }
}
