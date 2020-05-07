using System.Collections.Generic;
using SocietyPass.Mobile.Services.Contracts.Domain;

namespace SocietyPass.Mobile.Services.Domain
{
    //TODO: This class does not match the api and will need to be changed when connecting to the services.
    public class Review:BaseEntity, IReview
    {
        public int RestaurantId { get; set; }
        public int Rating { get; set; }
        public string RatingText { get; set; }
        public string User { get; set; }
        public string Comment { get; set; }
    }
}