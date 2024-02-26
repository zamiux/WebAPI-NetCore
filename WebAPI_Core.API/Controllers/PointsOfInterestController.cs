using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using WebAPI_Core.API.Model;
using WebAPI_Core.API.VM;

namespace WebAPI_Core.API.Controllers
{
    [ApiController]
    [Route("api/Cities/{cityId}/PointOfInsterest")]
    public class PointsOfInterestController : ControllerBase
    {
        #region dependenct Injection
        private readonly ILogger<PointsOfInterestController> _logger;
        public PointsOfInterestController(ILogger<PointsOfInterestController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            //how to get service from program.cs in class/acrion (special)
            //HttpContext.RequestServices.GetService
        }
        #endregion

        [HttpGet]
        #region GetPoint

        public ActionResult<IEnumerable<PointOfInterest>> GetPoint(int cityId)
        {
            try
            {
                var city = CitiesDataStore.current.Cities
                .FirstOrDefault(c => c.Id == cityId);

                if (city == null)
                {
                    // start log
                    _logger.LogInformation($"City With id {cityId} Not Found!!");
                    // end log

                    return NotFound();
                }

                return Ok(city.pointOfInterests);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception City With id {cityId}",ex);
                return StatusCode(500,"A Problem Happend !!!");
            }
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

        [HttpPatch("{pointofinterestId}")]
        #region Update with Patch
        public ActionResult UpdatePartialPointofInterest(int cityId
            , int pointofinterestId,
            JsonPatchDocument<PointOfInterest> patchDocument
            )
        {
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

            var pointofinterestForPatch = new PointOfInterest()
            {
                Name = point_data.Name,
                Description = point_data.Description
            };

            patchDocument.ApplyTo(pointofinterestForPatch, ModelState);


            //valication model state
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!TryValidateModel(pointofinterestForPatch))
            {
                return BadRequest(modelState: ModelState);
            }
            //valication model state

            point_data.Name = pointofinterestForPatch.Name;
            point_data.Description = pointofinterestForPatch.Description;

            return NoContent();
        }
        #endregion

        [HttpDelete("{pointofinterestId}")]
        #region Delete
        public ActionResult DeletePointOfInterest(int cityId
            , int pointofinterestId)
        {
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

            //delete
            city_data.pointOfInterests.Remove(point_data);
            return NoContent();
        }
        #endregion
         
    }
}
