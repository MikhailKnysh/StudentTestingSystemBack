using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.Questions.Repositories
{
    public interface IQuestionRepository : IBaseRepository<QuestionEntity>
    {
        Task<List<QuestionEntity>> GetAll();
        
        Task<List<QuestionEntity>> GetAllQuestionsByThemeIdAsync(Guid themeId);

        Task<QuestionEntity> GetQuestionByIdAsync(Guid id);
        
        Task<List<QuestionEntity>> GetAllQuestionsByDifficultyAsync(int difficulty, Guid themeId);
        Task<int> GetQuestionsQuantityAsync();
        Task<QuestionEntity> GetNextQuestionAsync(int toSkip);
    }
}