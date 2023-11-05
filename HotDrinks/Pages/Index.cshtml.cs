using HotDrinks.Interfaces;
using HotDrinks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HotDrinks.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHotDrinksRepo _hotDrinksRepo;

        [BindProperty]
        public HotDrink Drink { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please select a drink")]
        public int SelectedDrinkId { get; set; }

        public List<HotDrink> Drinks { get; set; } = new List<HotDrink>();

        public IndexModel(IHotDrinksRepo hotDrinksRepo)
        {
            _hotDrinksRepo = hotDrinksRepo;
        }

        public async Task OnGetAsync()
        {
            Drinks = await _hotDrinksRepo.GetAllDrinks();
        }

        public async Task OnPostAsync()
        {
            if(SelectedDrinkId <= 0)
            {
                ModelState.AddModelError("SelectedDrinkId","Please select a drink");
				Drinks = await _hotDrinksRepo.GetAllDrinks();
			}
            try
            {
                Drink = await _hotDrinksRepo.GetDrinkById(SelectedDrinkId);
                Drinks = await _hotDrinksRepo.GetAllDrinks();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
        }
    }
}