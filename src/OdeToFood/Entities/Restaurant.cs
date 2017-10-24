namespace OdeToFood.Entities
{
    // adding the enum up here because it's not a simple string or int
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
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
