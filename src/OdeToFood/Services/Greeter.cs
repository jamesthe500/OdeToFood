using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// moded to the new folder, "Services"
// Namespace changed to follow convention
// Services handle things like connecctions to databases.
namespace OdeToFood.Services
{
    public interface IGreeter
    {
        string GetGreeting();
    }

    public class Greeter : IGreeter
    {
        private string _greeting;

        public Greeter(IConfiguration configuration)
        {
            _greeting = configuration["greeting"];
        }

        public string GetGreeting()
        {
            return _greeting;
        }
    }
}
