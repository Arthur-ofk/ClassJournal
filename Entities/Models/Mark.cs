using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Mark
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public int MarkValue { get; set; }
        public DateTime CreatedDate { get; set; }

        public  Guid StudentId { get; set; }    




    }
}
