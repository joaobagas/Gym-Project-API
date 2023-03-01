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
        public async Task<ActionResult<string>> Login([FromBody] UserDTO user)
        {
            try
            {
                var dbPassword = _dbContext.Passwords.FirstOrDefault(p => p.Username == user.Username);
                if (dbPassword == null) return BadRequest("Username not found!");
                string hash = Authentication.GenerateHash(user.Password, dbPassword.Salt);
                if (hash.Equals(dbPassword.Hash)) return Ok(Authentication.CreateToken(user));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
            return BadRequest("Wrong password!");
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="userDTO">Carries data related to the user between the client and the API.</param>
        /// <returns>Action result and a string with message regarding the action result.</returns>
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromBody] UserDTO userDTO)
        {
            try
            {
                var dbPassword = _dbContext.Passwords.FirstOrDefault(p => p.Username == userDTO.Username);
                var dbUser = _dbContext.Users.FirstOrDefault(u => u.Username == userDTO.Username);
                if (dbPassword != null | dbUser != null) return BadRequest("User already exists!");
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong!");
            }

            User user = new User("", new DateTime(), 1, 1, new DateTime());

            string salt = Authentication.GenerateSalt(5);
            string hash = Authentication.GenerateHash(userDTO.Password, salt);
            Password password = new Password(userDTO.Username, hash, salt);

            try
            {
                _dbContext.Users.AddAsync(user);
                _dbContext.Passwords.AddAsync(password);
                _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong!");
            }
            return Ok("User created!");
        }
    }
}