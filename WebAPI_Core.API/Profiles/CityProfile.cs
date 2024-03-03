using AutoMapper;
using WebAPI_Core.API.Entites;
using WebAPI_Core.API.Model;

namespace WebAPI_Core.API.Profiles
{
    public class CityProfile:Profile
    {
        #region Constructor
        // start auto mapper
        public CityProfile()
        {   // Entity : MAP => : View Model
            CreateMap<WebAPI_Core.API.Entites.City, CityDto>();
        }
        #endregion
    }
}
