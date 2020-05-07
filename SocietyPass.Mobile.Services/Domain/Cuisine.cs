using SocietyPass.Mobile.Services.Contracts.Domain;

namespace SocietyPass.Mobile.Services.Domain
{
    public class Cuisine: BaseEntity, ICuisine 
    {
        public string Name { get; set; }
    }
}