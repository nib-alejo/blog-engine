using Common;
using Common.Entities;
using System;
using System.Collections.Generic;

namespace Business
{
    public interface IBlogBL
    {
        void Insert(Blog[] blogList);
        void Update(Blog[] blogList);
        void DeleteById(Guid id);
        Blog[] GetByState(Guid stateId);
        bool ApproveOrReject(Guid id, Enums.Action action);
    }
}
