using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI_Core.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    
    public class AuthenticationController : ControllerBase
    {
        IConfiguration _configuration;
        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Class Model
        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; }
            public string? Password  { get; set; }
        }

        public class CityInfoUser 
        {
            public int UserId { get; set; }
            public string? UserName { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? City { get; set; }

            public CityInfoUser(int userid,string username,string first,string last,string cityname)
            {
                UserId = userid;
                UserName = username;
                FirstName = first;
                LastName = last;
                City = cityname;
            }
        }

        
        #endregion
        #region JWT Authenticate Generate
        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthenticationRequestBody requestBody)
        {
            var user = ValidateUserCredentials(requestBody.UserName, requestBody.Password);

            if (user == null)
            {
                return Unauthorized();
            }
            //create signiture
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"])
                );

            var signingcredentials = new SigningCredentials(
                securityKey,SecurityAlgorithms.HmacSha256
                );

            //claims
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("userId", user.UserId.ToString()));
            claimsForToken.Add(new Claim("fname", user.FirstName.ToString()));
            claimsForToken.Add(new Claim("lname", user.LastName.ToString()));

            //generate token
            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow, // start time token
                DateTime.UtcNow.AddHours(1), // Expire time token
                signingcredentials
                );

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);

        }

        //validate 
        private CityInfoUser ValidateUserCredentials(string? username,string? password)
        {
            return new CityInfoUser(1,username??"","mohsen","zamani","tehran");  
        }
        #endregion
    }
}
