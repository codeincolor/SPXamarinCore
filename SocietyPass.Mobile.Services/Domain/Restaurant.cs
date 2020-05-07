using System;
using System.Collections.Generic;
using SocietyPass.Mobile.Services.Contracts.Domain;

namespace SocietyPass.Mobile.Services.Domain
{
    public class Restaurant: BaseEntity, IRestaurant
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICuisine Cuisine { get; set; }
        public string Url { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string CountryId { get; set; }
        public string DeliveryPrice { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public bool IsParkingAvailble { get; set; }
        public bool IsValetAvailable { get; set; }
        public bool ServesBreakfast { get; set; }
        public bool ServesLunch { get; set; }
        public bool ServesDinner { get; set; }
        public bool ServesAlcohol { get; set; }
        public string PriceRange { get; set; }//TODO: shouldn't this be a min/max
        public string AggregateRating { get; set; }
        public string RatingText { get; set; }
        public string RatingColor { get; set; }
        public string ThumbnailImage { get; set; }
        public string ProfileImage { get; set; }
        public Menu Menu { get; set; }
        //public Menu Menu { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}