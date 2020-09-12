using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibMS.Entity.DtoModel
{
    public class BookCountDto
    {
        public int BookCountID { get; set; }

        [ForeignKey("BookInfo")]
        public int BookID { get; set; }
        public double TotalCount { get; set; }
    }
}