// changed the folder from Models to Entities.
// changed the namespace to follow the documetn structure.
// Distinction is that an entity is somethign you persist in the database?
namespace OdeToFood.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
