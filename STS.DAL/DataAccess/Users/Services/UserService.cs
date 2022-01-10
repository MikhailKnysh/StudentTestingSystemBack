using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using STS.Common.Auth.Models;
using STS.Common.Constans;
using STS.Common.Cryptography.Services;
using STS.Common.FluentResult.Extensions;
using STS.Common.Generators.Services;
using STS.Common.Models;
using STS.DAL.DataAccess.Users.Repositories;
using STS.DAL.EntityContext.Entitieas;

namespace STS.DAL.DataAccess.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStringGeneratorService _stringGeneratorService;
        private readonly IEncryptorService _encryptorService;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IStringGeneratorService stringGeneratorService,
            IEncryptorService encryptorService,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _stringGeneratorService = stringGeneratorService;
            _encryptorService = encryptorService;
            _mapper = mapper;
        }

        public async Task<Result<User>> GetUserByAuthDataAsync(AuthModel authModel)
        {
            var encryptUserData = _encryptorService.EncryptUserData(authModel.Email, authModel.Password);
            var foundedUser = await _userRepository
                .FindAsync(u => u.Email == authModel.Email && u.Password == encryptUserData);
            var userModel = _mapper.Map<User>(foundedUser);

            return userModel.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result> CreateUserAsync(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            var password = _stringGeneratorService.GeneratePassword();
            var encryptUserData = _encryptorService.EncryptUserData(userEntity.Email, password.Value);

            userEntity.Id = Guid.NewGuid();
            userEntity.Password = encryptUserData;
            var responseDb = await _userRepository.CreateAsync(userEntity);

            return responseDb.CheckDbResponse(ErrorConstants.UserError.UserNotCreated);
        }

        public async Task<Result> DeleteUserAsync(Guid id)
        {
            var foundedUser = await _userRepository.FindAsync(u => u.Id == id);
            var responseDb = await _userRepository.DeleteAsync(foundedUser);

            return responseDb.CheckDbResponse(ErrorConstants.UserError.UserNotCreated);
        }

        public async Task<Result> UpdateUserAsync(User user)
        {
            var foundedUser = await _userRepository.FindAsync(u => u.Id == user.Id);
            if (foundedUser is not null)
            {
                foundedUser.FirstName = user.FirstName;
                foundedUser.LastName = user.LastName;
                foundedUser.Email = user.Email;
            }

            var responseDb = await _userRepository.UpdateAsync(foundedUser);

            return responseDb.CheckDbResponse(ErrorConstants.UserError.UserNotCreated);
        }

        public async Task<Result<List<User>>> GetAllUsersByGroupIdAsync(Guid groupId)
        {
            var usersEntities = await _userRepository.WhereAsync(expression: u => u.Groups.Any(g => g.Id == groupId));
            var users = _mapper.Map<List<User>>(usersEntities);

            return users.CheckCollectionNullOrEmpty(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result<User>> GetUserByIdAsync(Guid id)
        {
            var userEntity = await _userRepository.FindAsync(u => u.Id == id);
            var user = _mapper.Map<User>(userEntity);

            return user.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result> ChangePasswordAsync(ChangePasswordModel changePasswordModel)
        {
            var result = Result.Fail(ErrorConstants.SessionErrors.InvalidAuthData);
            var encryptUserData = _encryptorService.EncryptUserData(changePasswordModel.Email, changePasswordModel.OldPassword);
            var foundedUser = await _userRepository
                .FindAsync(u => u.Email == changePasswordModel.Email && u.Password == encryptUserData);
            if (foundedUser is not null)
            {
                var userEntity = _mapper.Map<UserEntity>(foundedUser);
                var newPassword = _encryptorService.EncryptUserData(foundedUser.Email, changePasswordModel.NewPassword);
                userEntity.Password = newPassword;
                var responseDb = await _userRepository.UpdateAsync(userEntity);

                result = responseDb.CheckDbResponse(ErrorConstants.UserError.PasswordNotUpdated);
            }

            return result;
        }
    }
}