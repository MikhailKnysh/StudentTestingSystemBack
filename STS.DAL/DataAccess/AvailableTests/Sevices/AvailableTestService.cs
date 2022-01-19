using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using STS.Common.Constans;
using STS.Common.FluentResult.Extensions;
using STS.Common.Models;
using STS.DAL.DataAccess.AvailableTests.Repositories;
using STS.DAL.Entities;

namespace STS.DAL.DataAccess.AvailableTests.Sevices
{
    public class AvailableTestService : IAvailableTestService
    {
        private readonly IAvailableTestRepository _availableTestRepository;
        private readonly IMapper _mapper;

        public AvailableTestService(
            IAvailableTestRepository availableTestRepository,
            IMapper mapper
        )
        {
            _availableTestRepository = availableTestRepository;
            _mapper = mapper;
        }

        public async Task<Result> CreateAsync(AvailableTest availableTests)
        {
            var entity = _mapper.Map<AvailableTestEntity>(availableTests);
            entity.Student = null;
            entity.Id = Guid.NewGuid();
            entity.ThemeEntity = null;
            var responseDb = await _availableTestRepository.CreateAsync(entity);

            return responseDb.CheckDbResponse(ErrorConstants.AvailableTestError.AvailableTestNotCreated);
        }

        public async Task<Result<List<AvailableTest>>> GetByStudentId(Guid studentId)
        {
            var entities = await _availableTestRepository.GetAllByUserIdAsync(studentId);
            var result = _mapper.Map<List<AvailableTest>>(entities);

            return result.CheckCollectionNullOrEmpty(ErrorConstants.CommonErrors.DataNotFound);
        }
    }
}