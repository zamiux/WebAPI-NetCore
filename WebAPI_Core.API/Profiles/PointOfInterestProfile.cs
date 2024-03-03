using AutoMapper;
using WebAPI_Core.API.Model;

namespace WebAPI_Core.API.Profiles
{
    public class PointOfInterestProfile:Profile
    {
        #region Constructor
        public PointOfInterestProfile()
        {
            CreateMap<WebAPI_Core.API.Entites.PointOfInterest, Model.PointOfInterest>();
        }
        #endregion
    }
}
