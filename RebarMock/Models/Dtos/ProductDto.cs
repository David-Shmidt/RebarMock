using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RebarMock.Models.Dtos
{
    public class ProductDto
    {
        
        public int Id { get; set; }
        
        public string ProductName { get; set; }
        public int CategoryId {get;set;}
        public string Image{get;set;}

        public byte[] ImageData{get;set;}
        public float Price{get;set; }
        
        public ICollection<string> Ingredients {get;set;} = new List<string>();

        
    }

    
}
