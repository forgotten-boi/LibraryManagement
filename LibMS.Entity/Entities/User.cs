using LibMS.Entity.BaseEntity;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibMS.Entity.Entities
{
    public class User : BaseEntity<int>
    {
        public User()
        {
            this.AssignBookInfoes = new HashSet<AssignBookInfo>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public virtual ICollection<AssignBookInfo> AssignBookInfoes { get; set; }

    }
}