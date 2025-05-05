using CredVault.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CredVault.API.Models.DTO;
using CredVault.API.Models.Domain;
using CredVault.API.Repositories;
using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CredVault.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CredVaultDbContext dbContext;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(CredVaultDbContext dbContext, IUserRepository userRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        // GET all users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            // Call the Repository interface to retrieve data from the SQL Server using the method defined in the concrete repository class
            var usersDomain = await userRepository.GetAllAsync();

            // Then, map the domain model to DTO
            var usersDto = mapper.Map<List<UserDto>>(usersDomain);

            // Return teh DTO to the client
            return Ok(usersDto);
        }

        // GET specific user by id
        [HttpGet]
        [Route("{id:Guid}")] // Ensure the id parameter in the URL is a Guid
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            // Get user domain model from the database
            var userDomain = await userRepository.GetUserByIdAsync(id);

            // Check if database returns a null value
            if (userDomain == null) 
            {
                return NotFound();
            }

            // If not null, map user domain model to DTO. Return DTO to client (Never return the domain model back to client)
            return Ok(mapper.Map<UserDto>(userDomain));
        }

        // POST - a user can request to post their information
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AddUserRequestDto addUserRequestDto) // Create Dto class to hold this request body
        {
            // Map the DTO (from user request) to a domain model
            var userDomain = mapper.Map<User>(addUserRequestDto);

            // Use the domain model to create a user using DBContext and the repository
            userDomain = await userRepository.CreateUserAsync(userDomain);


            // Map the newly added user domain model with the to the Dto to send to the client
            var userDto = mapper.Map<UserDto>(userDomain);

            // POST methods return a 201 response which is returned by the CreatedAtAction() method
            return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
        }

        // PUT - allows a user to update their details
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequestDto updateUserRequestDto)
        {
            // Map the Dto to a domain model
            var userDomain = mapper.Map<User>(updateUserRequestDto);

            // Update user through the repository
            userDomain = await userRepository.UpdateUserAsync(id, userDomain);

            if (userDomain == null)
            {
                return NotFound();
            }

            // Map domain model to Dto to send back Ok response with body containing updated domain model
            return Ok(mapper.Map<UserDto>(userDomain));


        }

        // DELETE - method to delete a user from the database
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
 
            var userDomain = await userRepository.DeleteUserAsync(id);

            if (userDomain == null)
            {
                return NotFound();
            }

            // Map deleted domain model back to Dto to return in response body
            return Ok(mapper.Map<UserDto>(userDomain));
           
        }
    }
}
