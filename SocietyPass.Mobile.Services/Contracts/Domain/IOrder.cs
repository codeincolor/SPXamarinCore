using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyPass.Mobile.Services.Contracts.Domain
{
    public interface IOrder
    {
        int Id { get; set; }
        int RestaurantId { get; set; }
        int UserId { get; set; }
        bool OrderPlaced { get; set; }
    }

    public interface IOrderItem
    {
        int Id { get; set; }
        int orderId { get; set; }
        int MenuItemId { get; set; }
        int Quantity { get; set; }
        string SpecialInstructions { get; set; }
    }
}
