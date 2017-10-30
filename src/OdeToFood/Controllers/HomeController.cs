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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // now that there is validation in the EditViewModel, 
        // this will exicute the validation rules to see if valid or not
        [HttpPost]
        // this validation will check the cookie that the site assigns is the same as it's getting from the user
        // this protects against cross-site request forgeries
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            // can check the state of our Model
            // by checking a property inherited from base class,
            // the base controller class 
            // with IsValid, will only be posted if it passes.
            if(ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Name = model.Name;
                newRestaurant.Cuisine = model.Cuisine;

                newRestaurant = _restaurantData.Add(newRestaurant);

                return View("Details", newRestaurant);
            }
            // if no, just put them back at the current view, so they can fix it.
            // validation messages will be shown through Create.cshtml 
            return View();
        }
    }
}
