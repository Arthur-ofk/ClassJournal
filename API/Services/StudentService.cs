using AutoMapper;
using Contracts;
using Entities.Models;
using Services.Contracts;
using Shared.DataTransferObject;
using System.ComponentModel.Design;

namespace Services
{
    internal sealed class StudentService : IStudentService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public StudentService(IRepositoryManager repository, ILoggerManager
 logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<StudentDto> GetStudents(Guid GroupId, bool trackChanges)

        {
            try
            {

                var studentsFromDb = _repository.Student.GetStudents(GroupId,
                 trackChanges);

                var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(studentsFromDb);


                return studentsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetStudents)}service method {ex}");

                throw;
            }

        }
        public StudentDto GetStudent(Guid groupId, Guid id, bool trackChanges)
        {
           

            var studentDb = _repository.Student.GetStudent(groupId, id, trackChanges);

            var student = _mapper.Map<StudentDto>(studentDb);
            return student;

        }

        public StudentDto CreateStudentForGroup(Guid GroupId, StudentForCreationDto studentForCreation , bool trackChanges)
        {
            var group = _repository.Group.GetGroup(GroupId, trackChanges);
            var studentEntity = _mapper.Map<Student>(studentForCreation);
            _repository.Student.CreateStudentForGroup(GroupId, studentEntity);
            _repository.Save();
            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);
            return studentToReturn;
        }


        public void DeleteStudentForGroup(Guid GroupId, Guid id, bool trackChanges)
        {
            var StudentForDelete = _repository.Student.GetStudent(GroupId, id, trackChanges);

            _repository.Student.DeleteStudent(StudentForDelete);
            _repository.Save();
        }

        public void UpdateStudentForGroup(Guid groupId, Guid id, StudentForUpdateDto studentForUpdate, bool grTrackChanges, bool stTrackChanges)
        {
            var group = _repository.Group.GetGroup(groupId, grTrackChanges);
            if (group == null)
            {
                throw new InvalidDataException();
            }
            var student = _repository.Student.GetStudent(groupId,id, stTrackChanges);
            if (student == null)
            {
                throw new InvalidDataException();
            }
            _mapper.Map(studentForUpdate, student);
            _repository.Save();
        }

        
    }
}
