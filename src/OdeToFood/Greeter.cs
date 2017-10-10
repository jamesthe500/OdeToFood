using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood
{
    // writing an interface to define the capabilities of every greeter
    public interface IGreeter
    {
        // every greeter will have the method "GetGreeting()"
        string GetGreeting();
    }

    public class Greeter : IGreeter
    {
        // intellisense generated this from squigglies at first calling
        private string _greeting;

        // this constructor demands that the user passin in an IConfiguration
        public Greeter(IConfiguration configuration)
        {
            // Private field 
            _greeting = configuration["greeting"];
        }

        // this was auto implemented with intellisense
        public string GetGreeting()
        {
            // replace hard-code with greeting from 
            return _greeting;
        }
    }
}
