using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetAllGroups(bool trackChanges);
        IEnumerable<Group> GetbyIds(IEnumerable<Guid> ids, bool trackChanges);
        Group GetGroup(Guid groupId, bool trackChanges);

        void CreateGroup(Group group);
        void DeleteGroup(Group group);
    }
}
