using System;
using System.Collections.Generic;
using LibMS.Entity.BaseEntity;

namespace LibMS.Entity.Entities
{
    public class BookInfo : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Details { get; set; }
        
        public BookInfo()
        {
            this.AssignBookInfoes = new HashSet<AssignBookInfo>();
            this.BookCountInfo = new BookCountInfo();
        }
        public virtual ICollection<AssignBookInfo> AssignBookInfoes { get; set; }

        public virtual BookCountInfo BookCountInfo { get; set; }
        //public virtual ICollection<BookCountInfo> BookCountInfoes { get; set; }
    }
}