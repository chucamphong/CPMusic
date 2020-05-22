using CPMusic.Data.Interfaces;
using CPMusic.Models;
using Microsoft.EntityFrameworkCore;

namespace CPMusic.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
