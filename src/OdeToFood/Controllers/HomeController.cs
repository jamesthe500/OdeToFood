using Microsoft.AspNetCore.Mvc;
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

        // this is temporarily returning a string just for testing purposes.
        // when we browse to /home/details/4 it renders "4" 
        // it is taking the 4 at the end of the URL as a parameter and returning it.
        // recall that in Startup.cs we have the default route "{controller=home}/{action=Index}/{id?}"
        // so that third part of the path is already known as "id"
        // this also works for a query string, i.e. /home/details?id=5
        // in this case, we get 4. It favors routing data over query string /home/details/4?id=5
        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            // other ways to handle the null possiblity
            if (model == null)
            {
                // this one isn't so great . It's just a 404 page
                //return NotFound();

                // redirects are a better approach, and there are many to choose from.
                // will send it to that other action result. 
                // the "nameof" method makes refactoring later on handy.
                // this sends the user back to the home page
                return RedirectToAction(nameof(Index));

            }

            // we'll return this view, which warrants creating one...
            return View(model);
        }
    }
}
