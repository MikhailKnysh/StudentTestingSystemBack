using Common.Models;
using FluentResults;
using System.Threading.Tasks;
using STS.DAL.EntityContext.Entitieas;

namespace STS.DAL.Interfaces
{
    public interface ISubjectService
    {
        Task<Result> CreateAsync(Subject subject);

        Task<Result<Subject>> FindByTitleAsync(string title);
    }
}