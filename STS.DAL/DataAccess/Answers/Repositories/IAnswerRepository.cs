using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.Answers.Repositories
{
    public interface IAnswerRepository : IBaseRepository<AnswerEntity>
    {
        Task<List<AnswerEntity>> GetAllByQuestionID(Guid questionId);
    }
}