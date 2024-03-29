﻿using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class StudentRepository : RepositoryBase<Student>, IStudentRepository

    {
        public StudentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        //public IEnumerable<Student> GetAllStudents(Guid groupId, bool trackChanges)
        //{
        //    throw new NotImplementedException();
        //}



        //public IEnumerable<Student> GetAllStudents(bool trackChanges) =>
        //FindAll(trackChanges)
        // .OrderBy(c => c.StudentName)
        // .ToList();

        public IEnumerable<Student> GetStudents(Guid groupId, bool trackChanges) =>
              FindByCondition(e => e.GroupId.Equals(groupId), trackChanges)
              .OrderBy(e => e.StudentName).ToList();

        public Student GetStudent(Guid groupId, Guid id, bool trackChanges) =>
            FindByCondition(c => c.GroupId.Equals(groupId) && c.Id.Equals(id), trackChanges)
            .SingleOrDefault();

        public void CreateStudentForGroup(Guid groupId, Student student)
        {
            student.Id = Guid.NewGuid(); 
            student.GroupId = groupId;
            Create(student);
        }

        public void DeleteStudent(Student student) => Delete(student);
        



        //public IEnumerable<Student> GetStudents(Guid groupId, bool trackChanges) =>
        //   FindByCondition(e => e.GroupId.Equals(groupId), trackChanges)
        //   .OrderBy(e => e.StudentName).ToList();

    }
}
