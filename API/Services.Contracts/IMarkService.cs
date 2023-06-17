﻿using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IMarkService
    {
        MarkDto CreateMark(MarkForCreationDto markForCreation , bool trackChanges);
    }
}
