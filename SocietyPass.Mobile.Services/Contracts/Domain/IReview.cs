using System;
using System.Collections.Generic;

namespace SocietyPass.Mobile.Services.Contracts.Domain
{
    public interface IReview
    {
        int Id { get; set; }
        int RestaurantId { get; set; }
        int Rating { get; set; }
        string RatingText { get; set; }
        //TODO: add other domain entities
        //public User User { get; set; }
        //public List<Comment> Comments { get; set; }
    }
}