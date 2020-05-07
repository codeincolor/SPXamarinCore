using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SocietyPass.Mobile.Core.ViewModels;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Core.Contracts.Services
{
    public interface INavigationService
    {
        //TODO: Move Cart/Order Info to its own service.
        int CartCount { get; set; }
        ObservableCollection<OrderItem> OrderItems { get; set; }
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        Task NavigateToAsync(Type viewModelType);

        Task NavigateToAsync(Type viewModelType, object parameter);

        Task NavigateBackAsync();

        Task RemoveLastFromBackStackAsync();
   }
}