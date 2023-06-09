using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateSubject(Subject subject)
        {
            subject.Id = Guid.NewGuid();
          Create(subject);
        }

        public IEnumerable<Subject> GetAllSubjects(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(o => o.SubjectName).ToList();

        public IEnumerable<Subject> GetSubjectsByName(string Name, bool trackChanges)
        {
            var subjects = FindByCondition(o => o.SubjectName == Name, trackChanges).OrderBy(o => o.SubjectName).ToList();
            return subjects;
        }

       
       
    }
}
