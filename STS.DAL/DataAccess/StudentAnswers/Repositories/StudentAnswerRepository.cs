using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.DBContext;
using STS.DAL.Entities;

namespace STS.DAL.DataAccess.StudentAnswers.Repositories
{
    public class StudentAnswerRepository : BaseRepositoryAbstract<StudentAnswerEntity>,IStudentAnswerRepository
    {
        public StudentAnswerRepository(ApplicationContext context) : base(context)
        {
        }
    }
}