using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocietyPass.Mobile.Core.Model
{
    public class NavigationMenuItem : BindableObject
    {
        private string _title;
        private NavigationMenuItemType _menuItemType;
        private Type _viewModelType;
        private bool _isEnabled;

        public string Title
        {
            get => _title;

            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public NavigationMenuItemType MenuItemType
        {
            get => _menuItemType;

            set
            {
                _menuItemType = value;
                OnPropertyChanged();
            }
        }

        public Type ViewModelType
        {
            get => _viewModelType;

            set
            {
                _viewModelType = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get => _isEnabled;

            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public Func<Task> AfterNavigationAction { get; set; }
    }
}
