namespace Cw17.Models.Entities
{
    public class Category
    {
       public int Id { get; set; }
       public string Name { get; set; }
       
       public List<Product> Products { get; set; }

    }
}
