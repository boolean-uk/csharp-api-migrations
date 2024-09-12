using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Models.DTOs;
using exercise.pizzashopapi.Repository;

namespace exercise.pizzashopapi.Service
{
    public class PizzaService
    {
        
        private readonly IRepository<Pizza> _pizzaRepository;

        public PizzaService(IRepository<Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _pizzaRepository.GetAll();
        }

        public async Task<Pizza> GetPizza(int id)
        {
            return await _pizzaRepository.GetById(id);
        }

        public async Task<Pizza> CreatePizza(Pizza pizza)
        {
            var createdPizza = await _pizzaRepository.Create(pizza);

            return createdPizza;
        }
    }
}
