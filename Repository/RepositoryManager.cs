using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IGroupRepository> _groupRepository;
        private readonly Lazy<IStudentRepository> _studentRepository;
        private readonly Lazy<ISubjectRepository> _subjectRepository;
        private readonly Lazy<IMarkRepository> _markRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _groupRepository = new Lazy<IGroupRepository>(() => new
            GroupRepository(repositoryContext));
            _studentRepository = new Lazy<IStudentRepository>(() => new
            StudentRepository(repositoryContext));
            _subjectRepository = new Lazy<ISubjectRepository>(() => new 
            SubjectRepository(repositoryContext));
            _markRepository = new Lazy<IMarkRepository>(() => new
            MarkRepository(repositoryContext));
        }
        public IGroupRepository Group => _groupRepository.Value;
        public IStudentRepository Student => _studentRepository.Value;

        public ISubjectRepository Subject => _subjectRepository.Value;

        public IMarkRepository Mark => _markRepository.Value;

        public void Save() => _repositoryContext.SaveChanges() ; 
    }
}
