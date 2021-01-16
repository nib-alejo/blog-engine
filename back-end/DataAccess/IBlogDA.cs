using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IBlogDA
    {
        void Insert(Blog[] blogList);
        void Update(Blog[] blogList);
        Blog GetById(Guid id);
        Blog[] GetByState(Guid stateId);
        void DeleteById(Guid id);
    }
}
