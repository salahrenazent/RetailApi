using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IPaySettingsService
    {
        public PaySettings GetPaySettings();
        public bool SavePaySettings(PaySettings settings);
    }
}
