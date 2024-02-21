using Microsoft.AspNetCore.Mvc;
using WebAPI_Core.API.Model;

namespace WebAPI_Core.API.Controllers
{
    [ApiController] // anotaion for api in controller
    //[Route("api/cities")] // mitooni be controller route and masir ro moshakhas koni
    //[Route("api/[controller]")] // ba "[controller]" chon ye kalame Reserve Shodast,
    // be in soorat ke mifahme manzoore shoma name Controller hastesh. 
    [Route("api/Cities")]
    public class CitiesController : ControllerBase
    {

        //[HttpGet("api/cities")]
        //[HttpGet] // type data transfer
        //public JsonResult GetCities() 
        //{
        //    //return new JsonResult(
        //    //    new List<object>
        //    //    {
        //    //        new {id=1,name="tehran"},
        //    //        new {id=2,name="shiraz"},
        //    //        new {id=3,name="mashhad"}
        //    //    });

        //    //var result = new JsonResult(CitiesDataStore.current.Cities);
        //    //result.StatusCode = 200;

        //    return new JsonResult(CitiesDataStore.current.Cities);
        //}

        [HttpGet] // type data transfer
        public ActionResult<IEnumerable<City>> GetCities()
        {
            return Ok(CitiesDataStore.current.Cities);
        }

        //[HttpGet("{id}")]
        //public JsonResult GetSingleCity(int id)
        //{
        //    return new JsonResult(CitiesDataStore.current
        //        .Cities
        //        .FirstOrDefault(c=>c.Id == id));
        //}

        [HttpGet("{id}")]
        public ActionResult<City> GetCity(int id)
        {
            var cityToReturn = (CitiesDataStore.current
                .Cities
                .FirstOrDefault(c => c.Id == id));

            if (cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);
        }
    }
}
