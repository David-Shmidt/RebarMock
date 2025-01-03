﻿using System.ComponentModel.DataAnnotations;

namespace RebarMock.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IngredientName {get;set;}
        public bool IsAvialable {get;set;} = true;

        public ICollection<Product> Products { get; set;} = new List<Product>();
    }
}
