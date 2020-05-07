using System.Threading.Tasks;

namespace SocietyPass.Mobile.Core.Contracts.Services
{
    public interface IDialogService
    {
        Task ShowDialog(string message, string title, string buttonLabel);

        void ShowToast(string message);
    }
}