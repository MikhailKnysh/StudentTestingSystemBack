using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using STS.Common.Models;

namespace STS.DAL.DataAccess.Tests.Services
{
    public interface ITestService
    {
        Task<Result<Test>> CreateTestAsync(Guid userId, Guid themeId);
        Task<Result<List<Test>>> GetAllTestsByUserIdAsync(Guid userId);
        Task<Result<Test>> GetTestByIdAsync(Guid id);
        Task<Result> DeleteAsync(Guid id);
        Task<Result<List<Test>>> GetAllTestsByGroupAsync(Guid groupId);
    }
}