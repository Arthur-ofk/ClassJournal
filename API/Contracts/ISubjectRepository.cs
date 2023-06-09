using Entities.Models;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISubjectRepository
    {
        void CreateSubject(Subject subject);
        IEnumerable<Subject> GetAllSubjects(bool trackChanges);
        IEnumerable<Subject> GetSubjectsByName(string Name, bool trackChanges);
    }
}
