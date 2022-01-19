using System;
using System.Collections.Generic;
using System.Linq;
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
            var questions = await _context.Questions
                // .Include(e=>e.Answers)
                .Include(e => e.Theme)
                .ToListAsync();

            return questions;
        }

        public async Task<List<QuestionEntity>> GetAllQuestionsByThemeIdAsync(Guid themeId)
        {
            var a = await _context.Questions.ToListAsync();
            var questions = await _context.Questions
                // .Include(e => e.Answers)
                // .Include(e => e.Theme)
                .Where(e => e.ThemeId == themeId)
                .ToListAsync();

            return questions;
        }

        public async Task<QuestionEntity> GetQuestionByIdAsync(Guid id)
        {
            var question = await _context.Questions
                .Include(e => e.Answers)
                .Include(e => e.Theme)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            return question;
        }

        public async Task<List<QuestionEntity>> GetAllQuestionsByDifficultyAsync(int difficulty, Guid themeId)
        {
            var questions = await _context.Questions
                .Include(e => e.Answers)
                .Include(e => e.Theme)
                .Where(q => q.ThemeId == themeId && q.Difficulty == difficulty)
                .ToListAsync();

            return questions;
        }

        public async Task<int> GetQuestionsQuantityAsync()
        {
            var quantity = await _context.Questions.CountAsync();

            return quantity;
        }

        public async Task<QuestionEntity> GetNextQuestionAsync(int toSkip)
        {
            var question = await _context.Questions
                .Include(e => e.Answers)
                .Skip(toSkip).Take(1).FirstOrDefaultAsync();

            return question;
        }
    }
}