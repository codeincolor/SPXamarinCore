using System;
using System.Collections.Generic;
using System.Text;
using SocietyPass.Mobile.Services.Contracts.Domain;

namespace SocietyPass.Mobile.Services.Domain
{
    public class Order : BaseEntity, IOrder
    {
        public string OrderId { get; set; }
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public bool OrderPlaced { get; set; }
    }

    public class OrderItem : BaseEntity, IOrderItem
    {
        public int orderId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public string SpecialInstructions { get; set; }
        public MenuItem MenuItem { get; set; }
        public decimal Total => Quantity * MenuItem.Price;
    }

}
