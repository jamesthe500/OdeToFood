using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    
    [Route("company/[controller]/[action]")]
    public class AboutController
    {
        public string Phone()
        {
            return "(507) 284-2511";
        }
        
        public string Address()
        {
            return "Rochester";
        }
    }
}
