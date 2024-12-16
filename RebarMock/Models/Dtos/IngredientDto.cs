using System.ComponentModel.DataAnnotations;

namespace RebarMock.Models.Dtos
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string IngredientName {get;set;}
        public bool IsAvialable {get;set;} = true;

        //public ICollection<Product> Products { get; set;} = new List<Product>();
    }
}
