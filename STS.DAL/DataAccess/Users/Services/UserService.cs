using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using STS.Common.Auth.Models;
using STS.Common.Constans;
using STS.Common.FluentResult.Extensions;
using STS.Common.Models;
using STS.DAL.DataAccess.Users.Repositories;

namespace STS.DAL.DataAccess.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Result<User>> GetUserByAuthData(AuthModel authModel)
        {
            var foundedUser = await _userRepository
                .FindAsync(u => u.Email == authModel.Email && u.Password == authModel.Password);
            var userModel = _mapper.Map<User>(foundedUser);

            return userModel.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
        }
    }
}