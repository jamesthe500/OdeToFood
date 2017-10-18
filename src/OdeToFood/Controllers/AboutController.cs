using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    // ATTRIBUTE ROUTING

    // Route Attribute
    // "in order to reach this controller, the first part of the url has to be 'about'
    //[Route("about")]

    // another way is with "TOKENS" these are inside the []
    // "in order to get this route, look for the controller below, i.e. "About"
    //[Route("[controller]")]

    // a third way, even more efficient. Can include literals.
    [Route("company/[controller]/[action]")]
    public class AboutController
    {
        // ...and then the next part of the url can be empty
        //[Route("")]

        // this way, if you need to refactor, so will the route refactor
        //[Route("[action]")]
        public string Phone()
        {
            return "(507) 284-2511";
        }

        // To get this controller, you need a route like /about/address
        //[Route("[action]")]
        public string Address()
        {
            return "Rochester";
        }

        /*
        public string Index()
        {
            return "Pointer finger";
        }
        */
    }
}
