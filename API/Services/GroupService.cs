using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Models;
using Services.Contracts;
using Shared.DataTransferObject;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Entities;
using Entities.Exceptions;

namespace Services
{
    internal class GroupService : IGroupService
    {
      
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        public GroupService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }
        public IEnumerable<GroupDto> GetAllGroups(bool trackChanges)
        {
            try
            {
                var groups =
                _repositoryManager.Group.GetAllGroups(trackChanges);
                var groupsDto = _mapper.Map<IEnumerable<GroupDto>>(groups);
                return (IEnumerable<GroupDto>)groupsDto;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(GetAllGroups)} service method {ex}");





                throw;
            }
        }

        public GroupDto GetGroup(Guid Id, bool trackChanges)
        {
            var group = _repositoryManager.Group.GetGroup(Id, trackChanges);
            if (group is null)
                throw new GroupNotFoundException(Id);
            var groupDto = _mapper.Map<GroupDto>(group);
            return groupDto;
        }
       public GroupDto CreateGroup(GroupForCreationDto group )
        {
            var groupEntity = _mapper.Map<Group>(group);
            _repositoryManager.Group.CreateGroup(groupEntity);
            _repositoryManager.Save();
            var groupToReturn = _mapper.Map<GroupDto>(groupEntity);
            return groupToReturn;
        }

        public IEnumerable<GroupDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids == null)
                throw new InvalidDataException();
            var groupEntities = _repositoryManager.Group.GetbyIds(ids,trackChanges);
            var groupsToReturn = _mapper.Map<IEnumerable<GroupDto>>(groupEntities);
            return groupsToReturn;
        }
        public (IEnumerable<GroupDto> companies, string ids) CreateGroupCollection
             (IEnumerable<GroupForCreationDto> companyCollection)
        {
          
            var companyEntities = _mapper.Map<IEnumerable<Group>>(companyCollection);
            foreach (var company in companyEntities)
            {
               _repositoryManager.Group.CreateGroup(company);
            }
            _repositoryManager.Save();
            var groupCollectionToReturn =
            _mapper.Map<IEnumerable<GroupDto>>(companyEntities);
            var ids = string.Join(",", groupCollectionToReturn.Select(c => c.Id));
            return (companies: groupCollectionToReturn, ids: ids);
        }

        public void DeleteGroup(Guid groupid , bool trackChanges)
        {
            var groupForDelete = _repositoryManager.Group.GetGroup(groupid, trackChanges);
            if (groupForDelete == null)
            {
                throw new InvalidDataException();
            }
            _repositoryManager.Group.DeleteGroup(groupForDelete);
            _repositoryManager.Save();
        }
    }
}
