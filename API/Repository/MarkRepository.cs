using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MarkRepository : RepositoryBase<Mark>, IMarkRepository
    {
        public MarkRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
