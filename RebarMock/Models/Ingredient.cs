using System.ComponentModel.DataAnnotations;

namespace RebarMock.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IngredientName {get;set;}
        public bool IsAvialable {get;set;} = true;

        public int ProductId {get;set; }
    }
}
