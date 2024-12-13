using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RebarMock.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public ICollection<Ingredient> Ingredients {get;set;} = new List<Ingredient>();

        public float Price { get; set; }    

        public string Image{get;set;} = "No image";

        [ForeignKey("Category")]
        [Required]
        public int CategoryId {get;set;}

        public Category Category {get;set; }

     }
}
