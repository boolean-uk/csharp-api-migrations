using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository.GenericRepositories;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository.SpecificRepositories
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly DataContext _dbContext;

        public MenuItemRepository(DataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItemsByType(string type)
        {
            return await _dbContext.MenuItems
                .Where(m => m.Type == type)
                .ToListAsync();
        }
    }
}
