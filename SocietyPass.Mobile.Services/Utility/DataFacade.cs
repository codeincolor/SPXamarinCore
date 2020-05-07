using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using SocietyPass.Mobile.Services.Domain;

namespace SocietyPass.Mobile.Services.Utility
{
    public class DataFacade
    {

        public IEnumerable<RestaurantListDto> GetRestaurants()
        {
            var rests = new List<RestaurantListDto>();

            var str = jsonData("restaurant");

            var j = JsonConvert.DeserializeObject<List<RestaurantListDto>>(str);

            return j;

        }
        public Restaurant GetRestaurantById(int id)
        {
            var rests = new List<RestaurantListDto>();
            var str = jsonData("restaurant");
            var j = JsonConvert.DeserializeObject<List<Restaurant>>(str);
            var rest = j.FirstOrDefault(r => r.Id == id);
            
            return rest;

        }

        public IEnumerable<Review> GetReviewsByRestId(int id)
        {
            var str = jsonData("review");
            var j = JsonConvert.DeserializeObject<List<Review>>(str);
            var rev = j.Where(r => r.RestaurantId == id);

            return rev;
        }
        public IEnumerable<Menu> GetMenusByRestId(int id)
        {
            var str = jsonData("menu");
            var j = JsonConvert.DeserializeObject<List<Menu>>(str);
            var rev = j.Where(r => r.RestaurantId == id);

            return rev;
        }
        public MenuItem GetMenuItemById(int id)
        {
            var rev = MenuItems().FirstOrDefault(m => m.Id == id);

            return rev;
        }

        private string jsonData(string entity)
        {
            var str = "";

            switch (entity)
            {
                case "restaurant":
                    str = "[" +
                  "{\"id\":1,\"name\":\"The Palm Moment\",\"cuisine\":null,\"city\":null,\"state\":null,\"priceRange\":null,\"thumbnailImage\":null,\"profileImage\":\"dashboard_thumbnail_11.jpg\", \"Description\": \"We care about the food we prepare in our restaurant.  We use only the finest ingredients. Please enjoy\"}," +
                  "{\"id\":2,\"name\":\"The Island Beehive\",\"cuisine\":null,\"city\":null,\"state\":null,\"priceRange\":null,\"thumbnailImage\":null,\"profileImage\":\"dashboard_thumbnail_19.jpg\", \"Description\": \"75 years of service. We cook with care, and you will taste the difference. The tastiest dishes in the area.\"}," +
                  "{\"id\":3,\"name\":\"Edible Moments\",\"cuisine\":null,\"city\":null,\"state\":null,\"priceRange\":null,\"thumbnailImage\":null,\"profileImage\":\"dashboard_thumbnail_20.jpg\", \"Description\": \"Whats in a tasty dish?  Anything that we make.  Our chefs take their time to prepare the best meals available for you to enjoy\"}," +
                  "{\"id\":4,\"name\":\"Fish and Chips Ship\",\"cuisine\":null,\"city\":null,\"state\":null,\"priceRange\":null,\"thumbnailImage\":null,\"profileImage\":\"dashboard_thumbnail_21.jpg\", \"Description\": \"There is nothing like satisfying a craving when it pops up.  just ask our thousands of clients.  they will tell there is no place better than here\"}," +
                  "{\"id\":5,\"name\":\"The Tropical Bistro\",\"cuisine\":null,\"city\":null,\"state\":null,\"priceRange\":null,\"thumbnailImage\":null,\"profileImage\":\"dashboard_thumbnail_22.jpg\", \"Description\": \"When you are really hungry we are the place you come to.  You appetite will be satisfied once you try our many great meals to choose from\"}," +
                  "{\"id\":6,\"name\":\"Lavender\",\"cuisine\":null,\"city\":null,\"state\":null,\"priceRange\":null,\"thumbnailImage\":null,\"profileImage\":\"dashboard_thumbnail_23.jpg\", \"Description\": \"Come and see us or give us a call to place your order.  We guarantee you wont regret trying our savory plates of great food \"}," +
                  "{\"id\":7,\"name\":\"Bambino\",\"cuisine\":null,\"city\":null,\"state\":null,\"priceRange\":null,\"thumbnailImage\":null,\"profileImage\":\"dashboard_thumbnail_12.jpg\", \"Description\": \"Using only the finest, Freshest ingredients. You are going to love our savory plates of food.  Come in and see us today!\"}," +
                  "{\"id\":8,\"name\":\"Pavilion\",\"cuisine\":null,\"city\":null,\"state\":null,\"priceRange\":null,\"thumbnailImage\":null,\"profileImage\":\"dashboard_thumbnail_13.jpg\", \"Description\": \"When you think great food you thing of us.  Take a look at some of the new menu items.  For takeout, Ordering in, or delivery.\"}," +
                  "{\"id\":9,\"name\":\"The Grove\",\"cuisine\":null,\"city\":null,\"state\":null,\"priceRange\":null,\"thumbnailImage\":null,\"profileImage\":\"dashboard_thumbnail_14.jpg\", \"Description\": \"Craving something new?  Come and visit us today for the some great food.  We know you will enjoy the comforts of home.\"}," +
                  "{\"id\":10,\"name\":\"The Turban\",\"cuisine\":null,\"city\":null,\"state\":null,\"priceRange\":null,\"thumbnailImage\":null,\"profileImage\":\"dashboard_thumbnail_15.jpg\", \"Description\": \"We are a full service restaurant with great drinks and food.  Happy hour is Monday through Friday.  Come in and treat yourself to a fine dining experience.\"}]";

                    break;
                case "review":
                    str = "[" +
                          "{\"restaurantId\":\"1\",\"rating\":\"3\",\"ratingText\":\"Great!\",\"user\":\"S Kinisin\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"1\",\"rating\":\"2\",\"ratingText\":\"Excellent Service\",\"user\":\"S Kinisin\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"1\",\"rating\":\"4\",\"ratingText\":\"Family Fun\",\"user\":\"S Smith\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"1\",\"rating\":\"3\",\"ratingText\":\"Recommended\",\"user\":\"S Roberts\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"2\",\"rating\":\"3\",\"ratingText\":\"Great Salads!\",\"user\":\"F Jones\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"2\",\"rating\":\"4\",\"ratingText\":\"Super time\",\"user\":\"S Lopez\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"2\",\"rating\":\"3\",\"ratingText\":\"Wonderful display!\",\"user\":\"S Kinisin\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"2\",\"rating\":\"2\",\"ratingText\":\"Not Bad\",\"user\":\"F Mchale\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"3\",\"rating\":\"3\",\"ratingText\":\"Good!\",\"user\":\"R Kuykendall\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"3\",\"rating\":\"3\",\"ratingText\":\"Will try again!\",\"user\":\"J Paul\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"4\",\"rating\":\"3\",\"ratingText\":\"Polite Servers\",\"user\":\"R Plant\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"4\",\"rating\":\"5\",\"ratingText\":\"One in a million!\",\"user\":\"R Rhoads\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"5\",\"rating\":\"3\",\"ratingText\":\"Should try\",\"user\":\"B Dahg\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"5\",\"rating\":\"1\",\"ratingText\":\"Pretty good\",\"user\":\"J Sharp\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"5\",\"rating\":\"3\",\"ratingText\":\"A little over priced..\",\"user\":\"B Gates\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"5\",\"rating\":\"4\",\"ratingText\":\"Service was good\",\"user\":\"S Tyler\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"5\",\"rating\":\"1\",\"ratingText\":\"Will try again.\",\"user\":\"S Williams\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"6\",\"rating\":\"2\",\"ratingText\":\"Great!\",\"user\":\"B Mahoney\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"6\",\"rating\":\"3\",\"ratingText\":\"Great!\",\"user\":\"R Joseph\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"6\",\"rating\":\"5\",\"ratingText\":\"Not Bad\",\"user\":\"D Ancestor\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"7\",\"rating\":\"4\",\"ratingText\":\"Great Food\",\"user\":\"M Cors\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"7\",\"rating\":\"3\",\"ratingText\":\"Great!\",\"user\":\"F Pallerdemo\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"7\",\"rating\":\"2\",\"ratingText\":\"Food was cold\",\"user\":\"S Kinisin\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"7\",\"rating\":\"1\",\"ratingText\":\"Great!\",\"user\":\"S Richards\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"7\",\"rating\":\"3\",\"ratingText\":\"Awesome dessert\",\"user\":\"S Kinisin\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"8\",\"rating\":\"3\",\"ratingText\":\"Not Bad\",\"user\":\"S Kinisin\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"8\",\"rating\":\"4\",\"ratingText\":\"Great!\",\"user\":\"D Richardson\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"8\",\"rating\":\"5\",\"ratingText\":\"Great!\",\"user\":\"A Alumn\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"8\",\"rating\":\"3\",\"ratingText\":\"Recommended\",\"user\":\"J Kim\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"8\",\"rating\":\"1\",\"ratingText\":\"Great!\",\"user\":\"S Park\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"9\",\"rating\":\"1\",\"ratingText\":\"Great!\",\"user\":\"J Wong\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"9\",\"rating\":\"2\",\"ratingText\":\"Great!\",\"user\":\"J Tripper\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"10\",\"rating\":\"4\",\"ratingText\":\"Great!\",\"user\":\"J Nguyen\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"10\",\"rating\":\"3\",\"ratingText\":\"Not Bad\",\"user\":\"T Raul\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"10\",\"rating\":\"2\",\"ratingText\":\"Great!\",\"user\":\"H Rollins\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"10\",\"rating\":\"3\",\"ratingText\":\"Great!\",\"user\":\"G Meter\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"10\",\"rating\":\"5\",\"ratingText\":\"Great!\",\"user\":\"H Burtz\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"10\",\"rating\":\"3\",\"ratingText\":\"Not Bad\",\"user\":\"W Smith\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"10\",\"rating\":\"1\",\"ratingText\":\"Great!\",\"user\":\"S Wesson\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"10\",\"rating\":\"3\",\"ratingText\":\"Nice time\",\"user\":\"S Winchestor\",\"comment\":\"Had a great experience.  Would Recommend\"}," +
                          "{\"restaurantId\":\"10\",\"rating\":\"2\",\"ratingText\":\"Great!\",\"user\":\"D Gone\",\"comment\":\"Had a great experience.  Would Recommend\"}]";


                    break;
                case "menu":
                    var mnus = new List<Menu>();
                    var mId = 0;
                    for (var i = 0; i <= 10; i++)
                    {
                        var mnu = new Menu{RestaurantId = i, Name = "Dinner", Id = i, MenuItems = new List<MenuItem>()};
                        mnu.MenuItems = MenuItems().Where(m => m.MenuId == i).ToList();
                        mnus.Add(mnu);
                    }
                    
                    str = JsonConvert.SerializeObject(mnus);

                    break;
                case "order":
                    break;
            }
           
            return str;

        }

        private List<MenuItem> MenuItems()
        {
            var hac =
                "A ham and cheese sandwich is a common type of sandwich. It is made by putting cheese and sliced ham between two slices of bread.[1] The bread is sometimes buttered and/or toasted. Vegetables like lettuce, tomato, onion or pickle slices can also be included. Various kinds of mustard and mayonnaise are also common.";
            var sd = "Soft drinks are called soft in contrast with hard alcoholic drinks. Small amounts of alcohol may be present in a soft drink, but the alcohol content must be less than 0.5% of the total volume of the drink in many countries and localities[1][2] if the drink is to be considered non-alcoholic.[3] Fruit punch, tea (even kombucha), and other such non-alcoholic drinks are technically soft drinks by this definition, but are not generally referred to as such.";
            var pc = "Potato chips (often just chips), or crisps, are thin slices of potato that have been deep fried or baked until crunchy. They are commonly served as a snack, side dish, or appetizer. The basic chips are cooked and salted; additional varieties are manufactured using various flavorings and ingredients including herbs, spices, cheeses, other natural flavors, artificial flavors, and additives.";
            var mnuItems = new List<MenuItem>();
            var mId = 0;
            for (var i = 0; i <= 10; i++)
            {
                mnuItems.Add(new MenuItem { Description = hac, DisplayImage = "dashboard_thumbnail_9.jpg", Id = mId++, Name = "Ham & Cheese Sandwich", ExtraInfo = "", MenuId = i, Price = Convert.ToDecimal(5.45) });
                mnuItems.Add(new MenuItem { Description = sd, DisplayImage = "dashboard_thumbnail_8.jpg", Id = mId++, Name = "Soft drink", ExtraInfo = "", MenuId = i, Price = Convert.ToDecimal(1.15) });
                mnuItems.Add(new MenuItem { Description = pc, DisplayImage = "dashboard_thumbnail_7.jpg", Id = mId++, Name = "Chips", ExtraInfo = "", MenuId = i, Price = Convert.ToDecimal(1.45) });
            }

            return mnuItems;
        }

    }
}
