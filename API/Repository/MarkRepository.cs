using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MarkRepository : RepositoryBase<Mark>, IMarkRepository
    {
        public MarkRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateMark(Mark mark)
        {
            
            Create(mark);
            
        }

        public void DeleteMark(Mark mark)=>Delete(mark);
       

        public IEnumerable<Mark> GetAllMarksForStudent(Guid StudentId, bool TrackChanges)
        {
            return FindByCondition(x => x.StudentId.Equals(StudentId), TrackChanges).ToList();
        }

        public Mark GetMarkById(Guid Id, bool TrackChanges)
        {
            return FindByCondition(o => o.Id == Id, TrackChanges).SingleOrDefault();
        }

        public IEnumerable<Mark> GetSubjectMarksForStudent(Guid StudentId, Guid SubjectId, bool TrackChanges)
        {
            return FindByCondition(x =>
            x.StudentId.Equals(StudentId), TrackChanges)
            .Where(x => x.SubjectId.Equals(SubjectId)).ToList();
        }
    }
}
