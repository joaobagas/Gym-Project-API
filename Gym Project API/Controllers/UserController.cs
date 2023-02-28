using Gym_Project_API.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Project_API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private DatabaseContext _dbContext;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContext = new DatabaseContext();
        }

        //[HttpPost("login")]
        //public async Task<ActionResult<string>> Login([FromBody] UserDTO user)
        //{
        //    try
        //    {
        //        var dbPassword = _dbContext.UserPasswords.FirstOrDefault(p => p.Username == user.Username);
        //        if (dbPassword == null) return BadRequest("Username not found!");
        //        string hash = Authentication.GenerateHash(user.Password, dbPassword.Salt);
        //        if (hash.Equals(dbPassword.Hash)) return Ok(Authentication.CreateToken(user));
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest("Something went wrong!");
        //    }
        //    return BadRequest("Wrong password!");
        //}
    }
}
