using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyPass.Mobile.Services.Domain
{
    public class MenuItem : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string DisplayImage { get; set; }
        public string Description { get; set; }
        public string ExtraInfo { get; set; }
        public int MenuId { get; set; }
    }
}
