using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IGroupService GroupService { get; }
        IStudentService StudentService { get; }
        IAuthenticationService AutentificationService { get; }
        ISubjectService SubjectService { get; }
        IMarkService MarkService { get; }
    }
}
