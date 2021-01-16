using System;

namespace Common.Entities
{
    public class BlogComment
    {
        public BlogComment() { }

        public Guid Id { get; set; }
        public Blog Blog { get; set; }
        public string Comment { get; set; }
        public DateTime Date
        {
            get { return Constants.unixEpoch.AddMilliseconds(DateTicks); }
            set { DateTicks = (long)value.Subtract(Constants.unixEpoch).TotalMilliseconds; }
        }
        public long DateTicks { get; set; }
    }
}
