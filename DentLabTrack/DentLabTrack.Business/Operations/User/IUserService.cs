using DentLabTrack.Business.Operations.User.Dtos;
using DentLabTrack.Business.Types;

namespace DentLabTrack.Business.Operations.User
{
    public interface IUserService
    {

        //This interface defines the contract for user management operations. It includes methods for adding a new user and logging in an existing user.
        Task<ServiceMessage> AddUser(AddUserDto user); 
        ServiceMessage<UserInfoDto> LoginUser(LoginUserDto loginUserDto);
    }
}
