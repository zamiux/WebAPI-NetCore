using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Core.API.Entites;
using WebAPI_Core.API.Model;
using WebAPI_Core.API.Repositories;

namespace WebAPI_Core.API.Controllers
{
    [ApiController] // anotaion for api in controller
    //[Route("api/cities")] // mitooni be controller route and masir ro moshakhas koni
    //[Route("api/[controller]")] // ba "[controller]" chon ye kalame Reserve Shodast,
    // be in soorat ke mifahme manzoore shoma name Controller hastesh. 
    [Route("api/Cities")]
    [Authorize]
    public class CitiesController : ControllerBase
    {
        #region Dependency Injection
        private readonly CitiesDataStore _CitydataStore;
        private readonly ICityRepository _cityRepository;
        //add auto mapper
        private readonly IMapper _mapper;
        public CitiesController(CitiesDataStore citydataStore,
            ICityRepository cityRepository,
            IMapper mapper)
        {
            _CitydataStore = citydataStore;
            _cityRepository = cityRepository ?? throw new ArgumentException(nameof(cityRepository));
            //auto mapper
            _mapper = mapper;
        }
        #endregion

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
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities()
        {
            //return Ok(_CitydataStore.Cities);
            var Cities = await _cityRepository.GetCitiesAsync();
            var result = new List<CityDto>();

            foreach (var city in Cities)
            {
                result.Add(new CityDto()
                {
                    Id = city.Id,
                    Name = city.Name,
                    Description = city.Description
                });
            }

            return Ok(result);

            #region Auto Mapper
            //return Ok(
            //    _mapper.Map<IEnumerable<CityDto>>(Cities)
            //    );
            #endregion
        }

        //[HttpGet("{id}")]
        //public JsonResult GetSingleCity(int id)
        //{
        //    return new JsonResult(CitiesDataStore.current
        //        .Cities
        //        .FirstOrDefault(c=>c.Id == id));
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Entites.City>> GetCity(int id,bool isExitpointOfInterest = false)
        {
            #region Old Code
            //var cityToReturn = (_CitydataStore
            //    .Cities
            //    .FirstOrDefault(c => c.Id == id));

            //if (cityToReturn == null)
            //{
            //    return NotFound();
            //}

            //return Ok(cityToReturn);
            #endregion

            #region Auto_Mapper
            var city_data = await _cityRepository.GetCityAsyncById(id, isExitpointOfInterest);

            if (city_data == null)
            {
                return NotFound();
            }

            if (isExitpointOfInterest == true)
            {
                return Ok(_mapper.Map<CityDto>(city_data));
            }

            return Ok(_mapper.Map<CityDto>(city_data));
            #endregion

        }
    }
}
