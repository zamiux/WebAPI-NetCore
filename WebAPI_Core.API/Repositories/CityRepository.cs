using Microsoft.EntityFrameworkCore;
using WebAPI_Core.API.dbContexts;
using WebAPI_Core.API.Entites;

namespace WebAPI_Core.API.Repositories
{
    
    public class CityRepository : ICityRepository
    {
        #region Dependency Injection
        private readonly WebApi_dbContext _context;
        public CityRepository(WebApi_dbContext context)
        {
            // Exception Null Handling
            _context = context ?? throw new ArgumentException(nameof(context));
        }
        #endregion
        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities
                .OrderBy(c=>c.Name)
                .ToListAsync();
        }

        public async Task<City?> GetCityAsyncById(int id,bool IncludePointOfInterest)
        {
            if (IncludePointOfInterest == true) {
                return await _context.Cities
                    .Include(c=>c.pointOfInterests)
                    .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            }

            return await _context.Cities.Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<PointOfInterest?> GetPointOfInterestAsyncById(int CityId, int PointOfInterestId)
        {
            return await _context.PointOfInterests
                .Where(c => c.CityId == CityId && c.Id == PointOfInterestId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PointOfInterest>> GetPointOfInterestsForCityAsync(int CityId)
        {
            return await _context.PointOfInterests
                .Where(c => c.CityId == CityId)
                .ToListAsync();
        }
    }
}
