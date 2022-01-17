using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
using STS.Common.Models;

namespace STS.DAL.DataAccess.AvailableTests.Sevices
{
    public interface IAvailableTestService
    {
        Task<Result> CreateAsync(AvailableTest availableTests);
        Task<Result<List<AvailableTest>>> GetByStudentId(Guid studentId);
    }
}