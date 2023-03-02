using Gym_Project_API.DataAccess;
using Gym_Project_API.Model;
using Gym_Project_API.Security;
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

        /// <summary>
        /// Checks the credentials of the user and logs them in.
        /// </summary>
        /// <param name="userDTO">Carries data related to the user between the client and the API.</param>
        /// <returns>Action result with a JSON Web Token if successful or an error message.</returns>
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(string username, string password)
        {
            try
            {
                var dbPassword = _dbContext.Passwords.FirstOrDefault(p => p.Username == username);
                if (dbPassword == null) return BadRequest("Username not found!");
                string hash = Authentication.GenerateHash(password, dbPassword.Salt);
                if (hash.Equals(dbPassword.HashedPassword)) return Ok(Authentication.CreateToken(username, _configuration));
            }
            catch { return BadRequest("Something went wrong!"); }
            return BadRequest("Wrong password!");
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="userDTO">Carries data related to the user between the client and the API.</param>
        /// <returns>Action result and a string with message regarding the action result.</returns>
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(string username, string name, DateTime birthday, int height, 
            int weight, string password)
        {
            try
            {
                var dbPassword = _dbContext.Passwords.FirstOrDefault(p => p.Username == username);
                var dbUser = _dbContext.Users.FirstOrDefault(u => u.Username == username);
                if (dbPassword != null | dbUser != null) return BadRequest("User already exists!");
            }
            catch { return BadRequest("Something went wrong!"); }

            User user = new User(username, name, birthday, height, weight, new DateTime());

            string salt = Authentication.GenerateSalt(5);
            string hash = Authentication.GenerateHash(password, salt);
            Password passwordObject = new Password(username, hash, salt);

            try
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.Passwords.AddAsync(passwordObject);
                await _dbContext.SaveChangesAsync();
            }
            catch { return BadRequest("Something went wrong!"); }
            return Ok("User created!");
        }
    }
}