namespace SocietyPass.Mobile.Services.Constants
{
    public class ApiConstants
    {
        //public static string BaseUrl = "http://192.168.1.12:5000/";
        //public static string BaseUrl = "http://192.168.1.189:5000/";
        public static string BaseUrl = "http://172.16.0.114:5000/";
        public static string ApiUrl = "api/v1.0/";
        public static string RestaurantsGetAll = "/restaurant";
        public static string RestaurantsGetById = "/restaurant/{0}";
        public static string Authenticate = "auth/authenticate";
        public static string ReviewsByRestaurantId = "/review";
        public static string ReviewsGetById = "/review/{0}";
    }
}