using HotDrinks.Models;
using Microsoft.EntityFrameworkCore;
using System;
using HotDrinks.Interfaces;
using HotDrinks.Data;
using System.Xml.Linq;

namespace HotDrinks.Models
{
    public class HotDrinksRepo : IHotDrinksRepo
    {
        private readonly DataContext _dataContext;

        public HotDrinksRepo(DataContext context)
        {
            _dataContext = context;
        }

        public async Task AddAction(HotDrinkAction action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action), "HotDrinkAction cannot be null.");
            }

            _dataContext.HotDrinkActions.Add(action);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AddHotDrink(HotDrink hotDrink)
        {
            if (hotDrink == null)
            {
                throw new ArgumentNullException(nameof(hotDrink), "HotDrink cannot be null.");
            }

            _dataContext.HotDrinks.Add(hotDrink);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<HotDrinkAction> GetActionByName(string name)
        {
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Action already exists.", nameof(name));
			}

			var result = await _dataContext
				.HotDrinkActions.Where(h => h.Name == name)
				.FirstOrDefaultAsync();

			return result;
		}

        public async Task<List<HotDrinkAction>> GetAllActions()
        {
            var result = await _dataContext.HotDrinkActions.ToListAsync();

            if (result == null)
            {
                throw new NullReferenceException("Failed to retrieve HotDrinkActions.");
            }

            return result;
        }

        public async Task<List<HotDrinkAction>> GetActionsByIds(List<int> actionIds)
        {

            if (actionIds == null)
            {
                throw new ArgumentNullException(nameof(actionIds), "List of ActionId cannot be null.");
            }

            var result = await _dataContext.HotDrinkActions
                .Where(action => actionIds.Contains(action.Id))
                .ToListAsync();

            return result;
        }

        public async Task<List<HotDrink>> GetAllDrinks()
        {
            var result = await _dataContext.HotDrinks
                .Include(d => d.Actions)
                .ToListAsync();

            if (result == null)
            {
                throw new NullReferenceException("Failed to retrieve HotDrinks.");
            }

            return result;
        }

        public async Task<HotDrink> GetDrinkById(int id)
        {

            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than 0.", nameof(id));
            }

            var result = await _dataContext
                .HotDrinks.Where(h => h.Id == id)
                .Include(d => d.Actions)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<HotDrink> GetDrinkByName(string name)
        {
			var result = await _dataContext
				.HotDrinks
                .Where(h => h.Name == name)
				.Include(d => d.Actions)
				.FirstOrDefaultAsync();

			return result;
		}

    }
}
