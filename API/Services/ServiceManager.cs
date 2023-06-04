using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Services.Contracts;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IGroupService> _groupService;

        private readonly Lazy<IStudentService> _studentService;
        private readonly Lazy<IAuthenticationService> _autentificationService;
      
        public ServiceManager(IRepositoryManager repositoryManager, 
            ILoggerManager logger, 
            IMapper mapper,
            UserManager<User> userManager,
            IConfiguration configuration)
        {

            _groupService = new Lazy<IGroupService>(() => new
            GroupService(repositoryManager, logger, mapper));
            _studentService = new Lazy<IStudentService>(() => new
            StudentService(repositoryManager, logger, mapper));
            _autentificationService = new Lazy<IAuthenticationService>(
                () => new AuthenticationService(logger, mapper, userManager, configuration));


        }
        public IGroupService GroupService => _groupService.Value;
        public IStudentService StudentService => _studentService.Value;

        public IAuthenticationService AutentificationService => _autentificationService.Value;
    }
}
