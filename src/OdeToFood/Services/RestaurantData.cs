using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public interface IRestaurantData
    {
        // this defines all the members that need to be implemented.
        IEnumerable<Restaurant> GetAll();
    }

    // later, we'll want to use a class that talks to SQL. 
    // having this class impement the interface will 
    // make it possible for the rest of the app to not knwo which 
    // class it's actually talking through.
    // the SQL class we make later will also implement IRestaurantData
    public class InMemoryRestaurantData : IRestaurantData
    {
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id=1, Name="Casa di Kobe" },
                new Restaurant {Id=2, Name="TJ's Astrological Love Lounge" },
                new Restaurant {Id=3, Name="Queen's Contraindication" }

            };
        }
        // b/c it's defined above, it needs to implement GetAll()
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        List<Restaurant> _restaurants;
    }
}
