using System.ComponentModel.DataAnnotations;

namespace HotDrinks.Models
{
    public class HotDrinkAction
    {
        public int Id { get; set; }
		[Required(ErrorMessage = "Name is required.")]
		[StringLength(20, ErrorMessage = "Name must be at most 20 characters.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Description is required.")]
		[StringLength(200, ErrorMessage = "Description must be at most 200 characters.")]
		public string Description { get; set; }
		public List<HotDrink>? Drinks { get; set; }
    }
}
