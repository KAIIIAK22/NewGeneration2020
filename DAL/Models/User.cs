using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
        public virtual ICollection<Media> Media { get; set; } = new List<Media>();
        public virtual ICollection<TemporaryMedia> TemporaryMedia { get; set; } = new List<TemporaryMedia>();
        public virtual ICollection<Attempt> Attempts { get; set; } = new List<Attempt>();

    }
}
