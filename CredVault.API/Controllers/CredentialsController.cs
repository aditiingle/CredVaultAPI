using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CredVault.API.Models.DTO;
using AutoMapper;
using CredVault.API.Models.Domain;
using CredVault.API.Repositories;

namespace CredVault.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly ICredentialRepository credentialRepository;

        public CredentialsController(IMapper mapper, ICredentialRepository credentialRepository)
        {
            this.mapper = mapper;
            this.credentialRepository = credentialRepository;

        }

        public IMapper Mapper { get; }

        [HttpPost]
        public async Task<IActionResult> CreateCredential([FromBody] AddCredentialRequestDto addCredentialRequestDto)
        {
            var credentialDomain = mapper.Map<Credential>(addCredentialRequestDto);

            await credentialRepository.CreateCredentialAsync(credentialDomain);

            var credentialDto = mapper.Map<CredentialDto>(credentialDomain);

            return Ok(credentialDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCredentials()
        {
            var credentialsDomain = await credentialRepository.GetAllCredentialsAsync();
            var credentialsDto = mapper.Map<List<CredentialDto>>(credentialsDomain);

            return Ok(credentialsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCredentialById([FromRoute] Guid id)
        {
            var credentialDomain = await credentialRepository.GetCredentialByIdAsync(id);

            if (credentialDomain == null)
            {
                return null;
            }

            return Ok(mapper.Map<CredentialDto>(credentialDomain));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCredential([FromRoute] Guid id, [FromBody] UpdateCredentialRequestDto updateCredentialRequestDto)
        {
            var credentialDomain = mapper.Map<Credential>(updateCredentialRequestDto);
            credentialDomain = await credentialRepository.UpdateCredentialAsync(id, credentialDomain);

            if (credentialDomain == null)
            {
                return NotFound();
            }

            var credentialDto = mapper.Map<CredentialDto>(credentialDomain);

            return Ok(credentialDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCredential([FromRoute] Guid id)
        {
            var credentialDomain = await credentialRepository.DeleteCredentialAsync(id);

            if (credentialDomain == null)
            {
                return NotFound();
            }

            var credentialDto = mapper.Map<CredentialDto>(credentialDomain);

            return Ok(credentialDto);
        }
    }
}
