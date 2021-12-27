using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Context;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.Questions.Repositories
{
    public class QuestionRepository : BaseRepositoryAbstract<QuestionEntity>, IQuestionRepository
    {
        public QuestionRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<QuestionEntity>> GetAll()
        {
            var questions = await _context.Questions.ToListAsync();

            return questions;
        }
    }
}