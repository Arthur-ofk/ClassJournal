using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Services.Contracts;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IGroupService> _groupService;

        private readonly Lazy<IStudentService> _studentService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {

            _groupService = new Lazy<IGroupService>(() => new
            GroupService(repositoryManager, logger, mapper));
            _studentService = new Lazy<IStudentService>(() => new
            StudentService(repositoryManager, logger, mapper));


        }
        public IGroupService GroupService => _groupService.Value;
        public IStudentService StudentService => _studentService.Value;

    }
}
