using HotDrinks.Data;
using HotDrinks.Interfaces;
using HotDrinks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotDrinks.Pages
{
	public class AddDrinksModel : PageModel
	{
		private readonly IHotDrinksRepo _hotDrinksRepo;

		[BindProperty]
		public HotDrink NewDrink { get; set; }

		public List<HotDrink> AllDrinks { get; set; } = new List<HotDrink>();

		public List<HotDrinkAction> AllActions { get; set; } = new List<HotDrinkAction>();

		[BindProperty]
		public List<int> SelectedActionIds { get; set; } = new List<int>();

		public AddDrinksModel(IHotDrinksRepo hotDrinksRepo)
		{
			_hotDrinksRepo = hotDrinksRepo;
		}
		public async Task OnGetAsync()
		{
			var hotDrinkActions = await _hotDrinksRepo.GetAllActions();
			var hotDrinks = await _hotDrinksRepo.GetAllDrinks();
			AllActions = hotDrinkActions;
			AllDrinks = hotDrinks;
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var drink = await _hotDrinksRepo.GetDrinkByName(NewDrink.Name);

			if (string.IsNullOrEmpty(NewDrink.Name))
			{
				ModelState.AddModelError("", "Drink needs a name");
				return Page();
			}
			else if (drink != null)
			{
				ModelState.AddModelError("", $"Drink with name {NewDrink.Name} already exists");
				return Page();
			}
			else
			{
				try
				{
					var selectedActions = await _hotDrinksRepo.GetActionsByIds(SelectedActionIds);

					NewDrink.Actions = selectedActions;

					await _hotDrinksRepo.AddHotDrink(NewDrink);
				}
				catch(Exception ex)
				{
					ModelState.AddModelError("", ex.Message);
				}
			}

			return RedirectToPage();

		}
	}

}
