using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
   public record StudentForCreationDto ( string StudentName ,int StudentAge, string Role,string Adress,string Email,bool IsStateLearning,string PhoneNumber);
}
