using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LibMS.Entity.BaseEntity;

namespace LibMS.Entity.Entities
{
    public class AssignBookInfo : BaseEntity<int>
    {

        [ForeignKey("BookInfo")]
        public int BookID { get; set; }
        public virtual BookInfo BookInfo { get; set; }
        public virtual User User { get; set; }
        public int UserID { get; set; }
        public bool IsReturned { get; set; }
    }
}