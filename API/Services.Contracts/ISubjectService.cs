using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public  interface ISubjectService
    {
        SubjectDto CreateSubject(SubjectForCreationDto subject, bool trackChanges); 
        IEnumerable<SubjectDto> GetSubjects(bool trackChanges);
        SubjectDto GetSubjectById(Guid Id, bool trackChanges);
        void DeleteSubject(Guid subjectId,bool trackChanges);
    }
}
