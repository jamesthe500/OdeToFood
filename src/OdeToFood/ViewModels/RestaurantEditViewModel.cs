using OdeToFood.Entities;

// this model is just for taking in data from the Create view.
// we don't use the full Restaurant model as there is data corruption possiblity.
namespace OdeToFood.ViewModels
{
    public class RestaurantEditViewModel
    {
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
