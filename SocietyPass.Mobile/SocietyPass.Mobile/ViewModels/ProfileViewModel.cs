using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class ProfileViewModel: BaseViewModel, IProfileViewModel
    {
        public ProfileViewModel(INavigationService navigationService, IDialogService dialogService, ISettingsService settingsService) : base(navigationService, dialogService, settingsService)
        {
        }


    }
}
