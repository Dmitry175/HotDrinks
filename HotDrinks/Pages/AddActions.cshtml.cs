using HotDrinks.Interfaces;
using HotDrinks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace HotDrinks.Pages
{
    public class AddActionsModel : PageModel
    {
		private readonly IHotDrinksRepo _hotDrinksRepo;

		[BindProperty]
		public HotDrinkAction HotDrinkAction { get; set; }

		public AddActionsModel(IHotDrinksRepo hotDrinksRepo)
		{
			_hotDrinksRepo = hotDrinksRepo;
		}
		public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
			if (string.IsNullOrEmpty(HotDrinkAction.Name) || string.IsNullOrEmpty(HotDrinkAction.Description))
			{
				ModelState.AddModelError("", "Please fill out all required fields.");
			}
			else
			{
				try
				{
					await _hotDrinksRepo.AddAction(HotDrinkAction);
				}
				catch(Exception ex) 
				{
					ModelState.AddModelError("", ex.Message);
				}
			}
			return Page();
		}
    }
}
