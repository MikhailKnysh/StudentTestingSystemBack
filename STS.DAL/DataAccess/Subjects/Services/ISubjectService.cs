using FluentResults;
using System.Threading.Tasks;

namespace STS.DAL.Interfaces
{
    public interface ISubjectService
    {
        Task<Result> CreateAsync(string name);
    }
}