using System;
using System.ComponentModel.DataAnnotations.Schema;
using LibMS.Entity.BaseEntity;

namespace LibMS.Entity.Entities
{
    public class BookCountInfo : BaseEntity<int>
    {
        [ForeignKey("BookInfo")]
        public int BookID { get; set; }
        
        public double BookCount { get; set; }
        public virtual BookInfo BookInfo { get; set; }
    }
}