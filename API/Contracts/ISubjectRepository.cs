using Entities.Models;

namespace Contracts
{
    public interface ISubjectRepository
    {
        void CreateSubject(Subject subject);
        IEnumerable<Subject> GetAllSubjects(bool trackChanges);
        IEnumerable<Subject> GetSubjectsByName(string Name, bool trackChanges);
    }
}
