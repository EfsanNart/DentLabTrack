using DentLabTrack.Business.DataProtection;
using DentLabTrack.Business.Operations.Doctor.Dtos;
using DentLabTrack.Business.Operations.User.Dtos;
using DentLabTrack.Business.Types;
using DentLabTrack.Data.Entities;
using DentLabTrack.Data.Enums;
using DentLabTrack.Data.Repositories;
using DentLabTrack.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Operations.User
{
    public class UserManager : IUserService   
    {
        //This class is responsible for user management operations such as adding a new user and logging in an existing user.

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IDataProtection _dataProtection;
        
        public UserManager(IUnitOfWork unitOfWork, IRepository<UserEntity> userRepository,IDataProtection dataProtection)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _dataProtection = dataProtection;
        }
        //This method is responsible for adding a new user. It checks if the email already exists and if not, it creates a new user entity and saves it to the database.
        public async Task<ServiceMessage> AddUser(AddUserDto user)
        {

            var hasMail = _userRepository.GetAll(x => x.Email.ToLower() == user.Email.ToLower());
            if (hasMail.Any())
            {
                return new ServiceMessage
                {
                    Message = "E-posta zaten mevcut",
                    IsSucceed = false
                };
            }
            var userEntity = new UserEntity()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = _dataProtection.Protect(user.Password),
                UserType = UserType.Admin 
            };
            _userRepository.Add(userEntity);
            try
            {
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw new Exception("Kullanıcı kaydedilirken bir hata oluştu");
            }
            return new ServiceMessage
            {
                Message = "Kullanıcı başarıyla kaydedildi",
                IsSucceed = true
            };
        }

        //This method is responsible for logging in a user. It checks if the user exists and if the password is correct.
        public ServiceMessage<UserInfoDto> LoginUser(LoginUserDto user)
        {
            var userEntity = _userRepository.Get(x => x.Email.ToLower() == user.Email.ToLower());
            if (userEntity is null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Kullanıcı adı veya şifre hatalı ",
                    
                };
            }
            var unprotectedPassword = _dataProtection.Unprotect(userEntity.Password);

            if (unprotectedPassword == user.Password)
            {
               return new ServiceMessage<UserInfoDto>
               {
                   
                   IsSucceed = true,
                   Data =new UserInfoDto
                   {
                       Email = userEntity.Email,
                       FirstName = userEntity.FirstName,
                       LastName = userEntity.LastName,
                       UserType = userEntity.UserType,
                   }
               };
            }
            else
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Kullanıcı Adı veya Şifre yanlış",
                   
                };
            }

        }
       
        }
}