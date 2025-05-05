using AutoMapper;
using CredVault.API.Models.Domain;
using CredVault.API.Models.DTO;



namespace CredVault.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<AddUserRequestDto, User>().ReverseMap();
            CreateMap<UpdateUserRequestDto, User>().ReverseMap();
        }

    }
}
