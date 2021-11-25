using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Context;
using STS.DAL.EntityContext.Entitieas;

namespace STS.DAL.DataAccess.Users.Repositories
{
    public class UserRepository : BaseRepositoryAbstract<UserEntity>, IUserRepository
    {
        public UserRepository(
            ApplicationContext context
        ) : base(context)
        {
        }
    }
}