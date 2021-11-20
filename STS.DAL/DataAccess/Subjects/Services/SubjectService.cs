using FluentResults;
using STS.DAL.Interfaces;
using System.Threading.Tasks;

namespace STS.DAL.DataAccess.Subjects.Services.Subjects
{
    public class SubjectService : ISubjectService
    {
        public Task<Result> CreateAsync(string name)
        {
            return null;
        }
    }
}