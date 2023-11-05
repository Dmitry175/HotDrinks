using HotDrinks.Interfaces;
using HotDrinks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System;

namespace HotDrinks.Pages
{
    public class DisplayActionsModel : PageModel
    {
        private readonly IHotDrinksRepo _hotDrinksRepo;
        public List<HotDrinkAction> HotDrinkActions { get; set; } = new List<HotDrinkAction>();

        [BindProperty]
        public HotDrinkAction HotDrinkAction { get; set; }

        public DisplayActionsModel(IHotDrinksRepo hotDrinksRepo)
        {
            _hotDrinksRepo = hotDrinksRepo;
        }
        public async Task OnGet()
        {
			var hotDrinkActions = await _hotDrinksRepo.GetAllActions();
            HotDrinkActions = hotDrinkActions;
        }
    }
}
