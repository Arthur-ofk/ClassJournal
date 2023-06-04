using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IStudentService
    {
        IEnumerable<StudentDto> GetStudents(Guid GroupId,bool trackChanges);
        StudentDto GetStudent(Guid groupId, Guid id, bool trackChanges);
        
        StudentDto CreateStudentForGroup(Guid GroupId,StudentForCreationDto studentForCreation,bool trackChanges );
        void DeleteStudentForGroup( Guid GroupId,Guid id,bool trackChanges );
        void UpdateStudentForGroup(Guid groupId,Guid id,StudentForUpdateDto studentForCreation,bool grTrackChanges,bool stTrackChanges );
    }
}
