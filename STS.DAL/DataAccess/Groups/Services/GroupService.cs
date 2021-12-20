using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using STS.Common.Constans;
using STS.Common.FluentResult.Extensions;
using STS.Common.Models;
using STS.DAL.DataAccess.Groups.Repositories;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.Groups.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(
            IGroupRepository groupRepository,
            IMapper mapper
        )
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<Result> CreateAsync(Group group)
        {
            var groupEntity = _mapper.Map<GroupEntity>(group);
            groupEntity.Id = Guid.NewGuid();
            groupEntity.Users = null;
            var responseDb = await _groupRepository.CreateAsync(groupEntity);

            return responseDb.CheckDbResponse(ErrorConstants.GroupErrors.GroupNotCreated);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var responseDb = 0;
            var foundedGroupEntity = await _groupRepository.FindAsync(e => e.Id == id);
            if (foundedGroupEntity is not null)
            {
                responseDb = await _groupRepository.DeleteAsync(foundedGroupEntity);
            }

            return responseDb.CheckDbResponse(ErrorConstants.GroupErrors.GroupNotDeleted);
        }

        public async Task<Result> UpdateAsync(Group group)
        {
            var responseDb = 0;
            var foundedGroupEntity = await _groupRepository.FindAsync(e => e.Id == group.Id);
            if (foundedGroupEntity is not null)
            {
                foundedGroupEntity.Name = group.Title;
                foundedGroupEntity.Users = null;
                responseDb = await _groupRepository.UpdateAsync(foundedGroupEntity);
            }

            return responseDb.CheckDbResponse(ErrorConstants.GroupErrors.GroupNotUpdated);
        }

        public async Task<Result<List<Group>>> GetAllAsync()
        {
            var groupsEntities = await _groupRepository.GetAllAsync();
            var groups = _mapper.Map<List<Group>>(groupsEntities);

            return groups.CheckCollectionNullOrEmpty(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result> AddUsersToGroup(GroupUsers groupUsers)
        {
            var responseDb = await _groupRepository.AddUsersToGroup(groupUsers.GroupId, groupUsers.UserIds);

            return responseDb.CheckDbResponse(ErrorConstants.GroupErrors.UserNotAdded);
        }
    }
}