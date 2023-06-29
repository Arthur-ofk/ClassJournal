using Entities.Models;

namespace Contracts
{
    public interface ISubjectRepository
    {
        void CreateSubject(Subject subject);
        IEnumerable<Subject>? GetAllSubjects(bool trackChanges);
        Subject? GetSubjectsById(Guid Id, bool trackChanges);

        void DeleteSubject(Subject subject, bool trackChanges);
    }
}
