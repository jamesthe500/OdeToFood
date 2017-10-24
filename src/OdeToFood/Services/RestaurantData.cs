using OdeToFood.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        // first add this definition for the method on the interface
        // this will return a restaurant and it takes the new restaurant we are adding.
        Restaurant Add(Restaurant newRestaurant);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        // this makes in not thread-safe. It will instatiate this list just once.
        // wouldn't want to use static in a concurrent users situation, fine for our demo purposes
        static InMemoryRestaurantData()
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
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        // making this static means that there will only be one instance of this list for the entire application
        static List<Restaurant> _restaurants;
    }
}
