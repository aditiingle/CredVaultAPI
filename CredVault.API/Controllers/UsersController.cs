using CredVault.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = dbContext.Users.ToList();

            return Ok(users);
        }

        public IActionResult GetById()
    }
}
