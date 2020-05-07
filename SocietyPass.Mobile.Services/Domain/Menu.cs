using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyPass.Mobile.Services.Domain
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public int RestaurantId { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
