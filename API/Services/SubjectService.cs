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

        public IEnumerable<SubjectDto> GetSubjects(bool trackChanges)
        {
            var subjects = _repositoryManager.Subject.GetAllSubjects(trackChanges);
            var subjectsToGet = _mapper.Map<IEnumerable<SubjectDto>>(subjects);
            return subjectsToGet;
        }

        public IEnumerable<SubjectDto> GetSubjectsByName(string name, bool trackChanges)
        {
            var subjects = _repositoryManager.Subject.GetSubjectsByName(name, trackChanges);
            var subjectsforReturn = _mapper.Map<IEnumerable<SubjectDto>>(subjects);
            return subjectsforReturn;
        }
    }
}
