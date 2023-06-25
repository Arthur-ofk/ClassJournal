using Entities.Models;

namespace Contracts
{
    public interface IMarkRepository
    {
        void CreateMark(Mark mark);
        IEnumerable<Mark> GetAllMarksForStudent(Guid StudentId, bool TrackChanges);
        IEnumerable<Mark> GetSubjectMarksForStudent(Guid StudentId, Guid SubjectId, bool TrackChanges);
        void DeleteMark(Mark mark);
    }
}
