using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Core.API.Controllers
{
    [ApiController] // anotaion for api in controller
    public class CitiesController : ControllerBase
    {
        public JsonResult GetCities() 
        {
            return new JsonResult(
                new List<object>
                {
                    new {id=1,name="tehran"},
                    new {id=2,name="shiraz"},
                    new {id=3,name="mashhad"}
                });
        }
    }
}
