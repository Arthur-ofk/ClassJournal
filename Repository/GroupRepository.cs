using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    internal class GroupRepository : RepositoryBase<Group>, IGroupRepository

    {
        public GroupRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateGroup(Group group) {
            group.Id = Guid.NewGuid();  
            Create(group);
        }

        public void DeleteGroup(Group group) => Delete(group);
        

        public IEnumerable<Group> GetAllGroups( bool trackChanges) =>
            FindAll(trackChanges).OrderBy(x => x.GroupName)
            .ToList();

        public IEnumerable<Group> GetbyIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.Id), trackChanges).ToList();
        

        public Group GetGroup(Guid groupId, bool trackChanges)=>
        
            FindByCondition(c => c.Id.Equals(groupId) , trackChanges)
            .SingleOrDefault();
        
    }
}
