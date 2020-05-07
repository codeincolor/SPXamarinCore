using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class DiscoverViewModel: BaseViewModel, IDiscoverViewModel
    {
        public DiscoverViewModel(INavigationService navigationService, IDialogService dialogService, ISettingsService settingsService) : base(navigationService, dialogService, settingsService)
        {
        }

  
    }
}
