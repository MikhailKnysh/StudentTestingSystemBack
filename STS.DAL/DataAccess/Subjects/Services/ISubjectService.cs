using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
using STS.Common.Models;

namespace STS.DAL.DataAccess.Subjects.Services
{
    public interface ISubjectService
    {
        Task<Result> CreateAsync(Subject subject);
        Task<Result<Subject>> GetById(Guid id);
        Task<Result<List<Subject>>> GetAll();
        Task<Result> UpdateAsync(Subject subject);
        Task<Result> DeleteAsync(Guid id);

        Task<Result<Subject>> FindByTitleAsync(string title);
    }
}