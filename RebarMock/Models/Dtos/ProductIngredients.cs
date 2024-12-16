namespace RebarMock.Models.Dtos
{
    public class ProductIngredientsDto
    {
        public string ProductName { get; set; }
        public int CategoryId {get;set;}
        public string Image{get;set;}
        public float Price{get;set; }

        public List<int> IngredientsIds {get;set;} = new List<int>();
    }
}
