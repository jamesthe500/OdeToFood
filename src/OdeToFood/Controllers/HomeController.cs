using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    // ususally, when cprogramming controllers, we derive from the base-class "Controller" of MS.AspNEtCore.Mvc
    //  
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // first thing it will do is instatniate new Restaurant (had to using this namespace)
            var model = new Restaurant
            {
                Id = 1,
                Name = "Casa di Kobe"
            };

            // returning this instead of simple text for the greater flexibility, and stuff.
            // it derives from IActionResult, thus that change above.
            //return Content( "Hello, from the Homecontroller");

            // this will serialize teh data and return it as json by default
            // this is great for an API
            return new ObjectResult(model);
        }        
    }
}
