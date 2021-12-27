using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Context;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.Answers.Repositories
{
    public class AnswerRepository : BaseRepositoryAbstract<AnswerEntity>, IAnswerRepository
    {
        public AnswerRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<AnswerEntity>> GetAllByQuestionID(Guid questionId)
        {
            var answerEnitities = await _context.Answers
                .Where(e => e.Id_Question == questionId)
                .ToListAsync();

            return answerEnitities;
        }
    }
}