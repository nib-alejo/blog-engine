using Common;
using Common.Entities;
using DataAccess;
using System;
using System.Linq;

namespace Business
{
    public class BlogBL : IBlogBL
    {
        public readonly IBlogDA iBlogDA;

        public BlogBL()
        {
            iBlogDA = new BlogDA();
        }

        public BlogBL(IBlogDA iBlogDA)
        {
            this.iBlogDA = iBlogDA;
        }

        public void Insert(Blog[] blogList)
        {
            if (blogList.Count() > 0)
            {
                iBlogDA.Insert(blogList);
            }
        }

        public void Update(Blog[] blogList)
        {
            if (blogList.Count() > 0)
            {
                iBlogDA.Update(blogList);
            }
        }

        public void DeleteById(Guid id)
        {
            iBlogDA.DeleteById(id);
        }

        public Blog[] GetByState(Guid stateId)
        {
            return iBlogDA.GetByState(stateId);
        }

        public bool ApproveOrReject(Guid id, Enums.Action action)
        {
            Blog blog = iBlogDA.GetById(id);

            if (blog == null)
                return false;

            if (action == Enums.Action.Approve)
            {
                blog.State.Id = Guid.Parse(Enums.BlogState.Approved.GetValueByProperty(Enums.Property.Id));
                blog.PublishDate = DateTime.UtcNow;
            }
            else if (action == Enums.Action.Reject)
            {
                blog.State.Id = Guid.Parse(Enums.BlogState.Rejected.GetValueByProperty(Enums.Property.Id));
            }

            Update(new Blog[] { blog });

            return true;
        }
    }
}
