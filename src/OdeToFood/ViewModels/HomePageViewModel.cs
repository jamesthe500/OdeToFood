using OdeToFood.Entities;
using System.Collections.Generic;

// ViewModels are like entites, but they carry the data into the view. 
// They're not for persistence.
namespace OdeToFood.ViewModels
{
    public class HomePageViewModel
    {
        // these are the things teh ViewModel will need for the view
        public string CurrentMessage { get; set; }
        // this holds all the Restaurant data
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
