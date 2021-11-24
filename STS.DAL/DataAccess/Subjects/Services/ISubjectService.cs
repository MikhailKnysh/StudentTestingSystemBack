using Common.Models;
using FluentResults;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace STS.DAL.Interfaces
{
    public interface ISubjectService
    {
        Task<Result> CreateAsync(Subject subject);
        Task<Result<Subject>> GetById(Guid id);
        Task<Result<IQueryable<Subject>>> GetAll();
        Task<Result> UpdateAsync(Subject subject);
        Task<Result> DeleteAsync(Guid id);

        Task<Result<Subject>> FindByTitleAsync(string title);
    }
}