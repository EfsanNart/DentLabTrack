using DentLabTrack.Business.Operations.User.Dtos;
using DentLabTrack.Business.Types;

namespace DentLabTrack.Business.Operations.User
{
    public interface IUserService
    {
        
        Task<ServiceMessage> AddUser(AddUserDto user); 
        ServiceMessage<UserInfoDto> LoginUser(LoginUserDto loginUserDto);
    }
}
