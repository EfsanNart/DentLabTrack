using DentLabTrack.Business.Operations.User.Dtos;
using DentLabTrack.Business.Types;

namespace DentLabTrack.Business.Operations.User
{
    public interface IUserService
    {
        /// UserService sınıfı, kullanıcı işlemlerini gerçekleştirmek için kullanılır..
        Task<ServiceMessage> AddUser(AddUserDto user); //async çünkü untiofwork kullanılacak
        ServiceMessage<UserInfoDto> LoginUser(LoginUserDto loginUserDto);
    }
}
