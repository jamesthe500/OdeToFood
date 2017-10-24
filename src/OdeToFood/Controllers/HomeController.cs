using Microsoft.AspNetCore.Mvc;
using OdeToFood.Entities;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IGreeter _greeter;
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }
        public IActionResult Index()
        {
            var model = new HomePageViewModel();

            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetGreeting();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
          
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // adding this route constraint as without, it errored. 
        // MVC doesn't know which Create action to use otherwise.
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // this version of the method takes an input parameter.
        // could make Restaurant the type of the parameter, 
        // but that's risky when you only want one or two fields populated.
        // the framework will try to populate fields from the http env, 
        // and you may end up getting fields maliciously or negligently populated.
        // this is why we added a class in the ViewModels folder for this input
        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            var newRestaurant = new Restaurant();
            newRestaurant.Name = model.Name;
            newRestaurant.Cuisine = model.Cuisine;

            newRestaurant = _restaurantData.Add(newRestaurant);

            // In the URL it'll show "create" since that's what rendered it, even if it's the Details view that was rendered.
            return View("Details", newRestaurant);
        }
    }
}
