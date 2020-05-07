using System;
using System.Collections.Generic;
using System.Text;
using SocietyPass.Mobile.Services.Contracts.Domain;

namespace SocietyPass.Mobile.Services.Domain
{
    public class RestaurantListDto: BaseEntity
    {
        public string Name { get; set; }
        public Cuisine Cuisine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PriceRange { get; set; }
        public string ThumbnailImage { get; set; }
        public string ProfileImage { get; set; }
        public string Description { get; set; }
    }
}
