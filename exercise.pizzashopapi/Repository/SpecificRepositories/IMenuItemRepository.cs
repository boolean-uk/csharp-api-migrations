using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository.GenericRepositories;

namespace exercise.pizzashopapi.Repository.SpecificRepositories
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        Task<IEnumerable<MenuItem>> GetMenuItemsByType(string type);
    }
}
