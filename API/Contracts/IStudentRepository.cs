using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents(Guid groupId, bool trackChanges);
        Student GetStudent(Guid groupId, Guid id, bool trackChanges);
        void CreateStudentForGroup(Guid groupId, Student student);
        void DeleteStudent(Student studentId);

    }
}
