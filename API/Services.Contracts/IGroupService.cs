
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IGroupService
    {
        IEnumerable<GroupDto> GetAllGroups(bool trackChanges);
       GroupDto GetGroup(Guid companyId, bool trackChanges);
        GroupDto CreateGroup(GroupForCreationDto company);
        IEnumerable<GroupDto> GetByIds(IEnumerable<Guid> ids,bool trackChanges);
        (IEnumerable<GroupDto> companies, string ids) CreateGroupCollection
            (IEnumerable<GroupForCreationDto> companyCollection);
         void DeleteGroup(Guid groupid, bool trackChanges);

    }
}
