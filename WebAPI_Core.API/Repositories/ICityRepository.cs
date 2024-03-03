using WebAPI_Core.API.Entites;

namespace WebAPI_Core.API.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City?> GetCityAsyncById(int id, bool IncludePointOfInterest);
        Task<IEnumerable<PointOfInterest>> GetPointOfInterestsForCityAsync(int CityId);
        Task<PointOfInterest?> GetPointOfInterestAsyncById(int CityId,int PointOfInterestId);
    }
}
