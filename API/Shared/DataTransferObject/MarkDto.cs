using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public record MarkDto(Guid Id,Guid SubjectId, int MarkValue, DateTime CreatedDate, Guid StudentId);
    
}
