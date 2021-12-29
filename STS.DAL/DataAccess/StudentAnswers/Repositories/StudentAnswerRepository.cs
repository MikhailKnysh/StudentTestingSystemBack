using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Context;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.StudentAnswers.Repositories
{
    public class StudentAnswerRepository : BaseRepositoryAbstract<StudentAnswerEntity>,IStudentAnswerRepository
    {
        public StudentAnswerRepository(ApplicationContext context) : base(context)
        {
        }
    }
}