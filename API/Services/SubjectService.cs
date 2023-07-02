using AutoMapper;
using Contracts;
using Entities.Models;
using Services.Contracts;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        public SubjectService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        

        public SubjectDto CreateSubject(SubjectForCreationDto subject, bool trackChanges)
        {
            var subjectToCreate = _mapper.Map<Subject>(subject);
            _repositoryManager.Subject.CreateSubject(subjectToCreate);
            _repositoryManager.Save();
            var subjectToreturn = _mapper.Map<SubjectDto>(subjectToCreate);
            return subjectToreturn;
        }

        public void DeleteSubject(Guid subjectId, bool trackChanges)
        {
            var subjectForDelete = _repositoryManager.Subject.GetSubjectById(subjectId, trackChanges);
            _repositoryManager.Subject.DeleteSubject(subjectForDelete,trackChanges);
            _repositoryManager.Save();

        }

        public IEnumerable<SubjectDto> GetSubjects(bool trackChanges)
        {
            var subjects = _repositoryManager.Subject.GetAllSubjects(trackChanges);
            var subjectsToGet = _mapper.Map<IEnumerable<SubjectDto>>(subjects);
            return subjectsToGet;
        }

        public SubjectDto GetSubjectById(Guid Id, bool trackChanges)
        {
            var subjects = _repositoryManager.Subject.GetSubjectById(Id, trackChanges);
            var subjectsforReturn = _mapper.Map<SubjectDto>(subjects);
            return subjectsforReturn;
        }
    }
}
