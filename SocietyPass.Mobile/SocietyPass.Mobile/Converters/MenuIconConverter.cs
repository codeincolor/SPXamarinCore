using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SocietyPass.Mobile.Core.Model;
using Xamarin.Forms;

namespace SocietyPass.Mobile.Core.Converters
{
    public class MenuIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            NavigationMenuItemType type = (NavigationMenuItemType)value;

            switch (type)
            {
                case NavigationMenuItemType.Home:
                    return "ic_home.png";
                case NavigationMenuItemType.Restaurants:
                    return "ic_restaurant.png";
                case NavigationMenuItemType.Discover:
                    return "ic_discover.png";
                case NavigationMenuItemType.Favorites:
                    return "ic_favorites.png";
                case NavigationMenuItemType.Profile:
                    return "ic_profile.png";
                case NavigationMenuItemType.Logout:
                    return "ic_logout.png";
                default:
                    return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
