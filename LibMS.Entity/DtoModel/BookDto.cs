using System;
using System.ComponentModel.DataAnnotations;

namespace LibMS.Entity.DtoModel
{
    public class BookDto
    {
        [Key]
        public int BookID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    }
}