using HotDrinks.Models;
using System.ComponentModel.DataAnnotations;

namespace HotDrinks.Models
{
    public class HotDrink
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20, ErrorMessage = "Name must be at most 20 characters.")]
        public string Name { get; set; }
        public List<HotDrinkAction> Actions { get; set; }
    }
}
