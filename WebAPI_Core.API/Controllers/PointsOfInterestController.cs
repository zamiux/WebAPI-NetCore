using Microsoft.AspNetCore.Mvc;
using WebAPI_Core.API.Model;
using WebAPI_Core.API.VM;

namespace WebAPI_Core.API.Controllers
{
    [ApiController]
    [Route("api/Cities/{cityId}/PointOfInsterest")]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        #region GetPoint

        public ActionResult<IEnumerable<PointOfInterest>> GetPoint(int cityId)
        {
            var city = CitiesDataStore.current.Cities
                .FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city.pointOfInterests);
        }
        #endregion

        [HttpGet("{pointofinterestId}", Name = "GetSinglePoint")]
        #region GetSinglePoint

        public ActionResult<IEnumerable<PointOfInterest>> GetSinglePoint(int cityId, int pointofinterestId)
        {
            var city = CitiesDataStore.current.Cities
                .FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var point = city.pointOfInterests
                .FirstOrDefault(p => p.Id == pointofinterestId);

            if (point == null)
            {
                return NotFound();
            }

            return Ok(point);
        }
        #endregion

        [HttpPost]
        #region Create

        public ActionResult<PointOfInterest> CreatePointOfInterest(int Cityid, CreatePointOfInterestViewModel ofInterestViewModel)
        {
            // check validation
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //if cityid input is Exist ? 
            var city_data = CitiesDataStore.current.Cities
                .FirstOrDefault(c => c.Id == Cityid);


            if (city_data == null)
            {
                return NotFound();
            }

            // max id pointofinterest
            var max_pointofinterestId = CitiesDataStore.current.Cities
                .SelectMany(c => c.pointOfInterests)
                .Max(p => p.Id);

            var new_point = new PointOfInterest()
            {
                Id = max_pointofinterestId + 1,
                Name = ofInterestViewModel.Name,
                Description = ofInterestViewModel.Description
            };


            city_data.pointOfInterests.Add(new_point);

            return CreatedAtAction("GetSinglePoint"
                , new { cityId = Cityid, pointofinterestId = new_point.Id }, new_point);
        }

        #endregion

        [HttpPut("{pointofinterestId}")]
        #region Update

        public ActionResult<PointOfInterest> UpdatePointOfInterest(int cityId
            , int pointofinterestId
            ,UpdatePointOfInterestViewModel updatePointOfInterest)
        {
            // check validation
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //if city input is Exist ? 
            var city_data = CitiesDataStore.current.Cities
                .FirstOrDefault(c => c.Id == cityId);


            if (city_data == null)
            {
                return NotFound();
            }

            //find point
            var point_data = city_data.pointOfInterests
                .FirstOrDefault(p => p.Id == pointofinterestId);

            if (point_data == null)
            {
                return NotFound();
            }

            point_data.Name = updatePointOfInterest.Name;
            point_data.Description = updatePointOfInterest.Description;

            return NoContent();
        }
        #endregion

    }
}
