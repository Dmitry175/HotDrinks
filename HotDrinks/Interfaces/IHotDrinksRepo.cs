using HotDrinks.Models;

namespace HotDrinks.Interfaces
{
    public interface IHotDrinksRepo
    {
        public Task AddAction(HotDrinkAction action);
        public Task<List<HotDrinkAction>> GetAllActions();
        public Task AddHotDrink(HotDrink hotDrink);
        Task<List<HotDrink>> GetAllDrinks();
        Task<List<HotDrinkAction>> GetActionsByIds(List<int> actionIds);
        Task<HotDrink> GetDrinkById(int id);
		Task<HotDrink> GetDrinkByName(string name);
	}
}
