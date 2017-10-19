using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    // ususally, when cprogramming controllers, we derive from the base-class "Controller" of MS.AspNEtCore.Mvc
    //  
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        // we are asking for an instance of IRestaurantData within our constructor
        public HomeController(IRestaurantData restaurantData)
        {
            // saves the restaurant data into a private field
            _restaurantData = restaurantData;
        }
        public IActionResult Index()
        {
            var model = _restaurantData.GetAll();

            return View(model);

             
        }        
    }
}
