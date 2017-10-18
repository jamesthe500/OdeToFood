using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    // this is the most simple kind of controller. 
    // It uses conventions with "Index" an "HomeController" that the middleware knows what to do with.
    // this proves the mvc was installed and configured correctly.
    public class HomeController
    {
        public string Index()
        {
            return "Hello, from the Homecontroller";
        }        
    }
}
