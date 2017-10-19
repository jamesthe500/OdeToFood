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

            // returns a "View" result which will generate HTML to send to the client
            // view results also implement IActionResults
            // Initially it errored. Says it looked for the file and path:
            // /Views/Home/Index.cshtml
            // follows the naming convention of short controller name, action name
            // to get it to work, added the needed folder structure and a cshtml file.
            //return View();

            // passing model so that the object is available to cshtml
            return View(model);

             
        }        
    }
}
