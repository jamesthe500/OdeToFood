// this namespace has all the annotations we'll need.
// annotations add requirements to a model's properties.
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Entities
{
    public enum CuisineType
    {
        None,
        Italian,
        French,
        Japanese,
        American,
        Sushi
    }

    public class Restaurant
    {
        public int Id { get; set; }

        // Display and displayformat are handy for the label rendered in view
        // displayFormat can give you currency symbols, numbers of decimal spaces...
        [Display(Name="Restaurant Name")]
        // this one would make the text box into a set of dots
        //[DataType(DataType.Password)]
        // Requried will prevent a submit without this field.
        // these affect HTML rendering. For actual validation, the server side code is more importatn. 
        // Client validatiaon cant be trusted.
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
