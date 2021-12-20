using System.Collections.Generic;
using System.Threading.Tasks;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.Questions.Repositories
{
    public interface IQuestionRepository : IBaseRepository<QuestionEntity>
    {
        Task<List<QuestionEntity>> GetAll();
    }
}