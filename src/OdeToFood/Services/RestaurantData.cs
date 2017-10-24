using OdeToFood.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        // adding this method to this
        // interface definiton that takes an id and returns a Restaurant
        Restaurant Get(int id);
    }

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

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Get(int id)
        {
            // The FirstOrDefault oporator from linq can be used
            // "given a restaurant, the one with the Id that matches the input id is the one we want
            // the default will be a null reference, if it can't find a matching Id
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        List<Restaurant> _restaurants;
    }
}
