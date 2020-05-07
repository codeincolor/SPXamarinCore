
using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Contracts.Services;
using Acr.UserDialogs;

namespace SocietyPass.Mobile.Core.Services
{
    public class DialogService : IDialogService
    {
        public Task ShowDialog(string message, string title, string buttonLabel)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }

        public void ShowToast(string message)
        {
            UserDialogs.Instance.Toast(message);
        }
    }
}
