using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    [Serializable]
    public record GroupDto
    {
        public Guid Id { get; init; }
        public string Info { get; init; }
    }
       
   
}
