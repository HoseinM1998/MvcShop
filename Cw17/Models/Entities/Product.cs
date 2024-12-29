using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cw17.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("اسم محصول")]
        [Required]
    
        public string Name { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
