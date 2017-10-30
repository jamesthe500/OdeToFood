using OdeToFood.Entities;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.ViewModels
{
    public class RestaurantEditViewModel
    {
        // adding validation here, on the model taht is just for taking in the data, is teh least corruptable way to validate
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
