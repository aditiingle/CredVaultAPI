using CredVault.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CredVault.API.Models.DTO;
using CredVault.API.Models.Domain;
using Azure.Identity;

namespace CredVault.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CredVaultDbContext dbContext;

        public UsersController(CredVaultDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET all users
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            // Get data from the database
            var usersDomain = dbContext.Users.ToList();

            // Then, map the domain model to DTO
            var usersDto = new List<UserDto>();
            foreach (var user in usersDomain)
            {
                usersDto.Add(new UserDto()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email
                });
            }

            // Return teh DTO to the client
            return Ok(usersDto);
        }

        // GET specific user by id
        [HttpGet]
        [Route("{id:Guid}")] // Ensure the id parameter in the URL is a Guid
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            // Get user domain model from the database
            var userDomain = dbContext.Users
                          .Where(x => x.Id == id)
                          .FirstOrDefault();

            // Check if database returns a null value
            if (userDomain == null) 
            {
                return NotFound();
            }

            // If not null, map user domain model to DTO
            var userDto = new UserDto()
            {
                Id = userDomain.Id,
                Username = userDomain.Username,
                Email = userDomain.Email
            };

            // Return DTO to client (Never return the domain model back to client)
            return Ok(userDto);
        }

        // POST - a user can request to post their information
        [HttpPost]
        public IActionResult CreateUser([FromBody] AddUserRequestDto addUserRequestDto) // Create Dto class to hold this request body
        {
            // Map the DTO (from user request) to a domain model
            var userDomain = new User
            {
                Username = addUserRequestDto.Username,
                Email = addUserRequestDto.Email
            };

            // Use the domain model to create a user using DBContext
            dbContext.Users.Add(userDomain);
            dbContext.SaveChanges();

            // Map the newly added user domain model with the to the Dto to send to the client
            var userDto = new UserDto
            {
                Id = userDomain.Id,
                Username = userDomain.Username,
                Email = userDomain.Email
            };

            // POST methods return a 201 response which is returned by the CreatedAtAction() method
            return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
        }

        // PUT - allows a user to update their details
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequestDto updateUserRequestDto)
        {
            // Ensure user exists
            var userDomain = dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (userDomain == null)
            {
                return NotFound();
            }

            // Map the Dto (request from client) to the domain model - store data from Dto in updateUserRequestDto instance
            userDomain.Username = updateUserRequestDto.Username;
            userDomain.Email = updateUserRequestDto.Email;

            // Save the update in the database from the domain model using DbContext
            dbContext.SaveChanges();

            // Map domain model to Dto to send back Ok response with body containing updated domain model
            var userDto = new UserDto
            {
                Id = userDomain.Id,
                Username = userDomain.Username,
                Email = userDomain.Email
            };
            
            return Ok(userDto);


        }

        // DELETE - method to delete a user from the database
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            // Ensure the user exists in DB
            var userDomain = dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (userDomain == null)
            {
                return NotFound();
            }

            // Delete the user from database
            dbContext.Users.Remove(userDomain);
            dbContext.SaveChanges();

            // Map deleted domain model back to Dto to return in response body
            var userDto = new UserDto
            {
                Id = userDomain.Id,
                Username = userDomain.Username,
                Email = userDomain.Email
            };

            return Ok(userDto);
           
        }
    }
}
