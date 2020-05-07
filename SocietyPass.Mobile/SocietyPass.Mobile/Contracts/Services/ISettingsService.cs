using System.Threading.Tasks;

namespace SocietyPass.Mobile.Core.Contracts.Services
{
    public interface ISettingsService
    {
        string AuthAccessToken { get; set; }
       
        bool GetValueOrDefault(string key, bool defaultValue);
        string GetValueOrDefault(string key, string defaultValue);
        Task AddOrUpdateValue(string key, bool value);
        Task AddOrUpdateValue(string key, string value);
        void AddItem(string key, string value);
        string GetItem(string key);
        string UserIdSetting { get; set; }
        string UserNameSetting { get; set; }
    }
}
