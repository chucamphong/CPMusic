using CPMusic.Data.Interfaces;
using CPMusic.Models;

namespace CPMusic.Data.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}