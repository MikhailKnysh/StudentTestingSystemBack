using Common.Models;
using FluentResults;
using System.Threading.Tasks;

namespace STS.DAL.Interfaces
{
    public interface ISubjectService
    {
        Task<Result> CreateAsync(SubjectModel subjectModel);
    }
}