using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class Blog
    {
        public Blog()
        {
            Author = new Employee();
            State = new DomainDetail();
        }

        [Required]
        public Guid Id { get; set; }

        [Required]
        public Employee Author { get; set; }

        [Required]
        public DomainDetail State { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Article { get; set; }

        public DateTime Date
        {
            get { return Constants.unixEpoch.AddMilliseconds(DateTicks); }
            set { DateTicks = (long)value.Subtract(Constants.unixEpoch).TotalMilliseconds; }
        }

        [Required]
        public long DateTicks { get; set; }

        
        public DateTime? PublishDate
        {
            get { return PublishDateTicks == null ? null : Constants.unixEpoch.AddMilliseconds(PublishDateTicks.Value); }
            set { PublishDateTicks = value == null ? null : (long)value.Value.Subtract(Constants.unixEpoch).TotalMilliseconds; }
        }
        public long? PublishDateTicks { get; set; }


        //Additional
        public BlogComment[] BlogCommentList { get; set; }
    }
}
