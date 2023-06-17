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
    public class MarkService : IMarkService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        public MarkService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }
        public MarkDto CreateMark(MarkForCreationDto markForCreation,bool trackChanges)
        {
           var mark = _mapper.Map<Mark>(markForCreation);
            Guid id = Guid.NewGuid();
            mark.Id = id;
            mark.CreatedDate = DateTime.Now;
            _repositoryManager.Mark.CreateMark(mark);
            _repositoryManager.Save();
            var markToReturn = _mapper.Map<MarkDto>(mark);
            return markToReturn;

        }
    }
}
