using System;
using System.Collections.Generic;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Services.Contracts.Domain
{
    public interface IRestaurant
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        ICuisine Cuisine { get; set; }
        string Url { get; set; }
        string Phone { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
        string CountryId { get; set; }
        string DeliveryPrice { get; set; }
        DateTime OpenTime { get; set; }
        DateTime CloseTime { get; set; }
        bool IsParkingAvailble { get; set; }
        bool IsValetAvailable { get; set; }
        bool ServesBreakfast { get; set; }
        bool ServesLunch { get; set; }
        bool ServesDinner { get; set; }
        bool ServesAlcohol { get; set; }
        string PriceRange { get; set; }//TODO: shouldn't this be a min/max
        string AggregateRating { get; set; }
        string RatingText { get; set; }
        string RatingColor { get; set; }
        IEnumerable<Review> Reviews { get; set; }

    }
}