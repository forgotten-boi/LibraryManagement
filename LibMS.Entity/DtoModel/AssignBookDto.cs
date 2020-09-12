
using LibMS.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibMS.Entity.DtoModel
{
    public class AssignBookDto
    {
        public AssignBookDto()
        {
           
        }
        [Key]
        public int AssignBookID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
        public bool IsReturned { get; set; }

        public virtual BookInfo BookInfo { get; set; }
        public virtual User User { get; set; }

    }
}